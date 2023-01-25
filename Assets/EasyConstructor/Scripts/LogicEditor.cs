using System.Collections;
using UnityEngine;
using UnityEditor;

using System;

using Object = UnityEngine.Object;
using System.Reflection;




[CustomEditor(typeof(Logic), true)]
public class LogicEditor : Editor
{


    private Logic logic;
    private SerializedProperty eventHandlers;

    void OnEnable()
    {
        eventHandlers = serializedObject.FindProperty("EventHandlers");
    }

    private GenericMenu addEventMenu;



    public override void OnInspectorGUI()
    {


        logic = target as Logic;

        if (addEventMenu == null)
            addEventMenu = BuildAddEventHandlersMenu();

        // Draw event list
        for (int i = 0; i < eventHandlers.arraySize; i++)
        {
            EditorGUILayout.PropertyField(eventHandlers.GetArrayElementAtIndex(i));

            Rect rect = GUILayoutUtility.GetLastRect();
            rect.x = rect.width - 50;
            rect.width = 50;
            rect.height = 15;

            if (GUI.Button(rect, new GUIContent("x")))
            {
           
                  logic.RemoveEventHandler(i);
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
      
        }

        Rect menuRect = EditorGUILayout.GetControlRect();

        if (EditorGUILayout.DropdownButton(new GUIContent("Add Event"), FocusType.Passive))
        {

           // string[] a = EventMenuBuilder.GetAllItems();
           // for (int i = 0; i < a.Length; i++)
            {
              //  Debug.Log(a[i]);
            }
              addEventMenu.DropDown(menuRect);
        }

        if (GUILayout.Button(new GUIContent("Clear Events")))
        {
            logic.ClearEventHandlers();
        }


        // Draw serialize
        /*
        for(int i = 0; i < logic.WrapperVariables.Count; i++)
        {
            Variable var = SerializableWrapper<Variable>.Deserialize(logic.WrapperVariables[i].serializedObject, logic.WrapperVariables[i].type);




            var.Name = EditorGUILayout.TextField(var.Name);

            logic.WrapperVariables[i].serializedObject = SerializableWrapper<Variable>.Serialize(var);
            
        }
        */

    }



    public string FindEnumNameInString(string source, Type type)
    {
        foreach (string t in Enum.GetNames(type))
        {
            if (source.Contains(t))
            {
                return t;
            }
        }
        return "";
    }

    public void AddEventHandler(object sourceString)
    {
        string group = "";
        string type = "";
        string properties = EventProperties.None;

        string[] source = sourceString.ToString().Split('/');

        if (source == null) return;

        if(source.Length >= 1) group = source[0];
        if(source.Length >= 2) type = source[1];
        if(source.Length >= 3) properties = source[2];


        

        Debug.Log(group + " " + type + " " + properties);



        EventHandler eventHandler = new EventHandler(group, type, properties);

        logic.AddEventHandler(eventHandler);
        

   

        /*
        if(properties is KeyboardEventHandlerProperties)
        {
           
            KeyboardEventHandler keyboardEvent = (KeyboardEventHandler) Activator.CreateInstance(typeof(KeyboardEventHandler));
            keyboardEvent.AssignPropertis( (KeyboardEventHandlerProperties) properties);

            Debug.Log(keyboardEvent);

            logic.AddEventHandler(keyboardEvent);
        }
        */


    }

    public GenericMenu BuildAddEventHandlersMenu()
    {
        GenericMenu menu = new GenericMenu();

        string[] allItems = EventMenuBuilder.GetAllEventWithProperties();

   

        for(int i = 0; i < allItems.Length; i++)
        {
            menu.AddItem(new GUIContent(allItems[i]), false, AddEventHandler, allItems[i]);
        }

        return menu;
     
    }

}
