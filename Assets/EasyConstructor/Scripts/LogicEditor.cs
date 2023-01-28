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
    private SerializedProperty variables;

    void OnEnable()
    {
        eventHandlers = serializedObject.FindProperty("EventHandlers");
        variables = serializedObject.FindProperty("variables");
    }

    private GenericMenu addEventMenu;



    public override void OnInspectorGUI()
    {


        logic = target as Logic;

        if (addEventMenu == null)
            addEventMenu = BuildAddEventHandlersMenu();


        if (logic.TryRemoveEventHandler() == true) return;
        if (logic.TryRemoveVariables() == true) return;

        // Draw event list
        for (int i = 0; i < eventHandlers.arraySize; i++)
        {
            EditorGUILayout.PropertyField(eventHandlers.GetArrayElementAtIndex(i));
      

            Rect rect = GUILayoutUtility.GetLastRect();
            rect.x = rect.width - 50;
            rect.width = 50;
            rect.height = 15;

          

            EditorGUILayout.Space();


        }

        // Draw variables list
        for (int i = 0; i < variables.arraySize; i++)
        {
            EditorGUILayout.PropertyField(variables.GetArrayElementAtIndex(i));

            Rect rect = GUILayoutUtility.GetLastRect();
            rect.x = rect.width - 50;
            rect.y -= 15;
            rect.width = 50;
            rect.height = 15;

           
        //    EditorGUILayout.Space();


        }

        
        Rect menuRect = EditorGUILayout.GetControlRect();

        menuRect.y -= 15;

        if (EditorGUILayout.DropdownButton(new GUIContent("Add Event"), FocusType.Passive))
        {

           // string[] a = EventMenuBuilder.GetAllItems();
           // for (int i = 0; i < a.Length; i++)
            {
              //  Debug.Log(a[i]);
            }
              addEventMenu.DropDown(menuRect);
        }


        if (EditorGUILayout.DropdownButton(new GUIContent("Add Variable"), FocusType.Passive))
        {


            BuildAddVariableMenu().DropDown(menuRect);
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
        



    }

    public void AddVariable(object indexVariableType)
    {
      
       logic.AddVariables(  (VariableTypeNames) indexVariableType);
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

    public GenericMenu BuildAddVariableMenu()
    {
        GenericMenu menu = new GenericMenu();

        string[] allItems = EventMenuBuilder.GetAllEventWithProperties();

        int index = 0;
        foreach(string variableTypeName in Enum.GetNames(typeof(VariableTypeNames)) )
        {
            menu.AddItem(new GUIContent(variableTypeName), false, AddVariable, index);
            index++;
        }        

        return menu;

    }

  
}
