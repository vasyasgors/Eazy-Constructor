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
        return base.GetPropertyHeight(property, label) + GetFieldActionsHeight(property.FindPropertyRelative("actions")) ;
      
    }




    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // возможно будут траблы и нужно иначе, 
        //   container = fieldInfo.GetValue(property.serializedObject.targetObject) as EventHandler; //  property.serializedObject.targetObject - игровой объект, (это скорее ссылка на комонент) и в нем находим полем



        var target = fieldInfo.GetValue(property.serializedObject.targetObject);

        Logic l = property.serializedObject.targetObject as Logic;
      //  Debug.Log(l);
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
                    eventHandler = ((List<EventHandler>)target)[index]; // Тут могут быть дети
                    
                else
                    eventHandler = ((EventHandler[])target)[index]; // Тут могут быть дети

    
            }
            catch  {
               // Debug.Log("Не получилось взять элемент из массива");
            }
         
        }
        else
        {
            eventHandler = fieldInfo.GetValue(property.serializedObject.targetObject) as EventHandler;
          
        }
        


        gameObject =  (property.serializedObject.targetObject as Component).gameObject;


       // EditorGUI.BeginProperty(position, label, property);

        GUI.Box(position, GUIContent.none);


        // Draw property name
        
        
        Rect nameRect = position;
        nameRect.height = 15;
        EditorGUI.LabelField(nameRect, new GUIContent( property.FindPropertyRelative("DispalyName").stringValue), EditorStyles.boldLabel);
        
        

       position.y += 15;


        Rect curActionRect = position;
        

        // Draw child properties

        // Изменять размер массива через пропертю, а задавать объект через target
        // Draw action fields
        for(int i = 0; i < property.FindPropertyRelative("actions").arraySize; i++)
        {

            SerializedProperty currentActionProperty = property.FindPropertyRelative("actions").GetArrayElementAtIndex(i);

            curActionRect.height = EditorGUI.GetPropertyHeight(currentActionProperty);

            EditorGUI.PropertyField(curActionRect, currentActionProperty);

           // EditorUtility.SetDirty(currentAction.objectReferenceValue); ???

            // Draw remove Button
            Rect removeButtonRect = curActionRect;
            removeButtonRect.y += 3;
            removeButtonRect.x = position.width - 70;
            removeButtonRect.width = 80;
            removeButtonRect.height = 15;

            if (GUI.Button(removeButtonRect, "Remove"))
            {

                //Undo.RecordObject(l, "Remove action");
   
                eventHandler.RemoveAction(currentActionProperty.objectReferenceValue as ActionBase);
            }

            // Draw  toogle condition
            removeButtonRect = curActionRect;
            removeButtonRect.y += 3;
            removeButtonRect.x = removeButtonRect.width - 70 - 85;
            removeButtonRect.width = 80;
            removeButtonRect.height = 15;

            if (GUI.Button(removeButtonRect, "Condition"))
            {
            
                eventHandler.ToogleActiveCondition(currentActionProperty.objectReferenceValue as ActionBase);
            }


            curActionRect.y += curActionRect.height + ActionVerticalOffset;

            
        }


        curActionRect.height = 15;

        if (EditorGUI.DropdownButton(curActionRect, new GUIContent("Add Action"), FocusType.Passive))
        {
            // Кешируем обработчик который выбрали( ДЛя массива) 
            //Undo.RecordObject(l, "Add action");

            addActionEventHandler = eventHandler;

            Debug.Log(eventHandler);

            BuildAddActionMenu().DropDown(curActionRect);




        }


   
       // EditorGUI.EndProperty();

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

        addActionEventHandler.AddAction(data.Type, gameObject);
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
        
        List<Type> allActionClasses =  GetAllSubclassOf(typeof(ActionBase)).ToList();

        List<ActionData> allActionPath = new List<ActionData>(); 

        for(int i = 0; i < allActionClasses.Count; i++)
        {
            object[] allAttributes = allActionClasses[i].GetCustomAttributes(false);

            for(int j = 0; j < allAttributes.Length; j++)
            {
                if(allAttributes[j] is ActionPathAttribute)
                {

                    ActionData data = new ActionData((allAttributes[j] as ActionPathAttribute).Path, allActionClasses[i]) ;

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
