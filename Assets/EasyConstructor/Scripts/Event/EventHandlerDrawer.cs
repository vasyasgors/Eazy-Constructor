using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System;

using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;

[CustomPropertyDrawer(typeof(EventHandler), true)]
public class EventHandlerDrawer : PropertyDrawer
{
    private const float ActionVerticalOffset = 5;
    private const float headerHeight = 20.0f;
    private const float actionTab = 15.0f;
    private const float ButtomButtonHeight = 15.0f;
    private const float CloseButtonWidth = 40.0f;

    private Color headerBackgroundColor = new Color(0.95f, 0.95f, 0.95f);

    private string actionsFieldName = "actions";


    private EventHandler eventHandler;

    private EventHandler eventHandlerToAddAction;

    private GameObject gameObject;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return GetFieldActionsHeight(property.FindPropertyRelative(actionsFieldName)) + headerHeight + ButtomButtonHeight;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var target = fieldInfo.GetValue(property.serializedObject.targetObject);

        if (target == null) return;

        IEnumerable enumerable = target as IEnumerable;
        if (enumerable == null)
            throw new InvalidOperationException("listData mist be enumerable");

        // Get Event Hander reference
        if (target.GetType().IsGenericType || target.GetType().IsArray)
        {

            var index = Convert.ToInt32(new string(property.propertyPath.Where(c => char.IsDigit(c)).ToArray()));
            try
            {

                if (target.GetType().IsGenericType)
                    eventHandler = ((List<EventHandler>)target)[index]; // Тут могут быть дети

                else
                    eventHandler = ((EventHandler[])target)[index]; // Тут могут быть дет
            }
            catch
            {
            }

        }
        else
        {
            eventHandler = fieldInfo.GetValue(property.serializedObject.targetObject) as EventHandler;
        }

        // Try remove actions
        if (eventHandler.TryRemoveAction() == true) return;

        // Chache gameObject
        gameObject = (property.serializedObject.targetObject as Component).gameObject;


        // Draw backround box
        Color prevColor = GUI.backgroundColor;
        Rect boxRect = position;
        boxRect.height -= ButtomButtonHeight;
        GUI.backgroundColor = new Color(0.95f, 0.95f, 0.95f);
        GUI.Box(boxRect, GUIContent.none);
        GUI.backgroundColor = prevColor;


        // Draw title action
        Rect headerRect = position;
        headerRect.height = headerHeight;

        prevColor = GUI.backgroundColor;
        GUI.backgroundColor = headerBackgroundColor;
        GUI.Box(headerRect, GUIContent.none);
        GUI.backgroundColor = prevColor;

        EditorGUI.LabelField(headerRect, new GUIContent(property.FindPropertyRelative("DispalyName").stringValue), EditorStyles.boldLabel);

        // Draw remove buttons
        Rect buttonRect = new Rect(position.x + position.width - CloseButtonWidth, position.y, CloseButtonWidth, headerHeight);
        if (GUI.Button(buttonRect, new GUIContent("✖"))) 
        {
            eventHandler.ToRemove = true;
        }

        // Draw add action button
        buttonRect = new Rect(position.x + position.width - CloseButtonWidth * 2, position.y, CloseButtonWidth, headerHeight);
        if (GUI.Button(buttonRect, new GUIContent("✚")))
        {
            eventHandlerToAddAction = eventHandler;

            BuildAddActionMenu().DropDown(buttonRect);
        }

        // Draw actions 
        Rect actionRect = position;
        actionRect.x += actionTab;
        actionRect.y += headerHeight + ActionVerticalOffset;
        actionRect.width -= actionTab;

        for (int i = 0; i < property.FindPropertyRelative(actionsFieldName).arraySize; i++)
        {
            SerializedProperty actionProperty = property.FindPropertyRelative(actionsFieldName).GetArrayElementAtIndex(i);
            actionRect.height = EditorGUI.GetPropertyHeight(actionProperty);
            EditorGUI.PropertyField(actionRect, actionProperty, true);
            actionRect.y += actionRect.height + ActionVerticalOffset;
        }

        
        // Draw add action button
        /*
        buttonRect = new Rect(position.x, actionRect.y - ActionVerticalOffset - 1, position.width, ButtomButtonHeight);

        if (EditorGUI.DropdownButton(buttonRect, new GUIContent("Add Action"), FocusType.Passive))
        {
            eventHandlerToAddAction = eventHandler;

            BuildAddActionMenu().DropDown(buttonRect);
        }*/
    }


    private float GetFieldActionsHeight(SerializedProperty actions)
    {
        float height = 0;

        for (int i = 0; i < actions.arraySize; i++)
        {
            SerializedProperty currentAction = actions.GetArrayElementAtIndex(i);

            height += EditorGUI.GetPropertyHeight(currentAction) + ActionVerticalOffset;
        }

        return height;
    }




    private void AddAction(object actionData)
    {
        ActionData data = actionData as ActionData;

        eventHandlerToAddAction.AddAction(data.Type, gameObject);
    }

    public class ActionData
    {
        public string Path;
        public Type Type;

        public ActionData(string path, Type type)
        {
            Path = path;
            Type = type;
        }
    }


    private GenericMenu BuildAddActionMenu()
    {
        GenericMenu menu = new GenericMenu();

        ActionData[] allActionPath = FindAllAction();

     

        for (int i = 0; i < allActionPath.Length; i++)
        {
             menu.AddItem(new GUIContent(allActionPath[i].Path), false, AddAction, allActionPath[i]);
        }

        return menu;

    }

    public ActionData[] FindAllAction()
    {

        List<Type> allActionClasses = GetAllSubclassOf(typeof(ActionBase)).ToList();

        List<ActionData> allActionPath = new List<ActionData>();

        for (int i = 0; i < allActionClasses.Count; i++)
        {
          
            object[] allAttributes = allActionClasses[i].GetCustomAttributes(false);

            for (int j = 0; j < allAttributes.Length; j++)
            {
                if (allAttributes[j] is ActionPathAttribute)
                {

                    ActionData data = new ActionData((allAttributes[j] as ActionPathAttribute).Path, allActionClasses[i]);

                    allActionPath.Add(data);
                }
            }
        }

        return allActionPath.ToArray();
    }

    public static IEnumerable<Type> GetAllSubclassOf(Type parent)
    {
        foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            foreach (var t in a.GetTypes())
                if (t.IsSubclassOf(parent)) yield return t;
    }

}