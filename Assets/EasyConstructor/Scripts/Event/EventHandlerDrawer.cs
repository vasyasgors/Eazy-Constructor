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

    private EventHandler eventHandler;

    private EventHandler addActionEventHandler;

    GameObject gameObject;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + GetFieldActionsHeight(property.FindPropertyRelative("actions")) + 15;
      
    }




    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // возможно будут траблы и нужно иначе, 
        //   container = fieldInfo.GetValue(property.serializedObject.targetObject) as EventHandler; //  property.serializedObject.targetObject - игровой объект, (это скорее ссылка на комонент) и в нем находим полем

        var target = fieldInfo.GetValue(property.serializedObject.targetObject);

        // костыль, при создании элемента массива, он не успевает? проинициализироваться 
        if (target == null) return;

        IEnumerable enumerable = target as IEnumerable;
        if (enumerable == null)
            throw new InvalidOperationException("listData mist be enumerable");

        if (target.GetType().IsGenericType || target.GetType().IsArray )
        {
    
            var index = Convert.ToInt32( new string(property.propertyPath.Where(c => char.IsDigit(c)).ToArray() ) );

            // заменить на иф


            try
            {



                /*
                int i = 0;
                foreach (object item in enumerable.OfType<object>())
                {
                    if (i == index)
                        eventHandler = item as EventHandler;

                    i++;

                    Debug.Log(item is EventHandler);
                 }

                */
                
                if (target.GetType().IsGenericType)
                    eventHandler = ((List<KeyboardEventHandler>)target)[index]; // Тут могут быть дети
                    
                else
                    eventHandler = ((KeyboardEventHandler[])target)[index]; // Тут могут быть дети

    
            }
            catch  {
                Debug.Log("Не получилось взять элемент из массива");
            }
         
        }
        else
        {
            eventHandler = fieldInfo.GetValue(property.serializedObject.targetObject) as EventHandler;
          
        }
        


        gameObject =  (property.serializedObject.targetObject as Component).gameObject;


        EditorGUI.BeginProperty(position, label, property);

        GUI.Box(position, GUIContent.none);


        // Draw property name
        
        
        Rect nameRect = position;
        nameRect.height = 15;
        EditorGUI.LabelField(nameRect, new GUIContent( property.FindPropertyRelative("DispalyName").stringValue), EditorStyles.boldLabel);
        
        

       position.y += 15;


        Rect curActionRect = position;
        

        // Draw child properties


        // Draw action fields
        for(int i = 0; i < property.FindPropertyRelative("actions").arraySize; i++)
        {

            SerializedProperty currentAction = property.FindPropertyRelative("actions").GetArrayElementAtIndex(i);

            curActionRect.height = EditorGUI.GetPropertyHeight(currentAction);

            EditorGUI.PropertyField(curActionRect, currentAction);

           // EditorUtility.SetDirty(currentAction.objectReferenceValue); ???

            // Draw remove Button
            Rect removeButtonRect = curActionRect;
            removeButtonRect.y += 3;
            removeButtonRect.x = position.width - 70;
            removeButtonRect.width = 80;
            removeButtonRect.height = 15;

            if (GUI.Button(removeButtonRect, "Remove"))
            {
   
                eventHandler.RemoveAction(currentAction.objectReferenceValue as ActionBase);
            }

            // Draw  toogle condition
            removeButtonRect = curActionRect;
            removeButtonRect.y += 3;
            removeButtonRect.x = removeButtonRect.width - 70 - 85;
            removeButtonRect.width = 80;
            removeButtonRect.height = 15;

            if (GUI.Button(removeButtonRect, "Condition"))
            {
            
                eventHandler.ToogleActiveCondition(currentAction.objectReferenceValue as ActionBase);
            }


            curActionRect.y += curActionRect.height + ActionVerticalOffset;
        }


        curActionRect.height = 15;

        if (EditorGUI.DropdownButton(curActionRect, new GUIContent("Add Action"), FocusType.Passive))
        {
            // Кешируем обработчик который выбрали( ДЛя массива) 
            addActionEventHandler = eventHandler;

            Debug.Log(eventHandler);

            BuildAddActionMenu().DropDown(curActionRect);

        }


   
        EditorGUI.EndProperty();

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




    private void AddAction(object name)
    {


        Debug.Log(addActionEventHandler);

        if (name.ToString() == "Destory Object")
            addActionEventHandler.AddAction<DestoryAction>(gameObject);

        if (name.ToString() == "Spawn Object")
            addActionEventHandler.AddAction<SpawnAction>(gameObject);

        if (name.ToString() == "Load Level")
            addActionEventHandler.AddAction<LoadLevelAction>(gameObject);

        if (name.ToString() == "Rotate")
            addActionEventHandler.AddAction<Rotate>(gameObject);

        if (name.ToString() == "Move")
            addActionEventHandler.AddAction<Move>(gameObject);

         if (name.ToString() == "Move To") addActionEventHandler.AddAction<MoveTo>(gameObject);
         if (name.ToString() == "Move To Random Area") addActionEventHandler.AddAction<MoveToRandomArea>(gameObject);
         if (name.ToString() == "Unity Event") addActionEventHandler.AddAction<UnityEventAction>(gameObject);




    }


    private GenericMenu BuildAddActionMenu()
    {
        GenericMenu menu = new GenericMenu();

        menu.AddItem(new GUIContent("Destory Object"), false, AddAction, "Destory Object");
        menu.AddItem(new GUIContent("Spawn Object"), false, AddAction, "Spawn Object");
        menu.AddItem(new GUIContent("Load Level"), false, AddAction, "Load Level");
        menu.AddItem(new GUIContent("Rotate"), false, AddAction, "Rotate");
        menu.AddItem(new GUIContent("Move"), false, AddAction, "Move");
        menu.AddItem(new GUIContent("Move To"), false, AddAction, "Move To");
        menu.AddItem(new GUIContent("Move To Random Area"), false, AddAction, "Move To Random Area");
        menu.AddItem(new GUIContent("Unity Event"), false, AddAction, "Unity Event");


        return menu;

    }

}
