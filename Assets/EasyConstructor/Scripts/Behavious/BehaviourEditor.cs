using System.Collections;
using UnityEngine;
using UnityEditor;

using System;

using Object = UnityEngine.Object;
using System.Reflection;




[CustomEditor(typeof(Behaviour), true)]
public class BehaviourEditor : Editor
{


    private Behaviour behaviour;
    private SerializedProperty eventHandlersProperty;
    private SerializedProperty variablesProperty;

    void OnEnable()
    {
        eventHandlersProperty = serializedObject.FindProperty("EventHandlers");
        variablesProperty = serializedObject.FindProperty("variables");
    }

    private GenericMenu cachedAddEventMenu;



    public override void OnInspectorGUI()
    {
        behaviour = target as Behaviour;

        if (cachedAddEventMenu == null)
            cachedAddEventMenu = BuildAddEventHandlersMenu();

        // Try delete
        if (behaviour.TryRemoveEventHandler() == true) return;
        if (behaviour.TryRemoveVariables() == true) return;

        // Title style
        GUIStyle titleStyle = new GUIStyle();
        titleStyle.fontSize = 14;
        titleStyle.fontStyle = FontStyle.Bold;


        // Draw Logic
        EditorGUILayout.LabelField("Logic", titleStyle);
        EditorGUILayout.Space();

        for (int i = 0; i < eventHandlersProperty.arraySize; i++)
        {
            EditorGUILayout.PropertyField(eventHandlersProperty.GetArrayElementAtIndex(i));
            EditorGUILayout.Space();
        }

        Rect rect = GUILayoutUtility.GetLastRect();
        if (GUILayout.Button( "Add Event"))
        {
            BuildAddEventHandlersMenu().DropDown(rect);
        }

        // Draw Variables
        EditorGUILayout.LabelField("Variables", titleStyle);
        EditorGUILayout.Space();

        for (int i = 0; i < variablesProperty.arraySize; i++)
        {
            EditorGUILayout.PropertyField(variablesProperty.GetArrayElementAtIndex(i));
          
        }

        rect = GUILayoutUtility.GetLastRect();
        if (GUILayout.Button("Add Variable"))
        {
            BuildAddVariableMenu().DropDown(rect);
        }




    }





    public void AddEventHandler(object sourceString)
    {
        string group = "";
        string type = "";
        string properties = EventProperties.None;

        string[] source = sourceString.ToString().Split('/');

        Debug.Log(sourceString);

        if (source == null) return;

        if (source.Length == 1) { group = EventGroups.LifeTime.ToString(); type = source[0]; } // хак для того, чтобы события жизненного цилка можно было отобрають без подменюшки 
        if (source.Length >= 2) { group = source[0]; type = source[1]; }
        if(source.Length >= 3)  properties = source[2];

        if (group == EventGroups.Keyboard.ToString())
        {
            properties = source[3];
        }


        EventHandler eventHandler = new EventHandler(group, type, properties);

        behaviour.AddEventHandler(eventHandler);
    }

    public void AddVariable(object indexVariableType)
    {
        behaviour.AddVariables(  (VariableTypes) indexVariableType);
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
        foreach(string variableTypeName in Enum.GetNames(typeof(VariableTypes)) )
        {
            if (variableTypeName == VariableTypes.Any.ToString()) continue;

            menu.AddItem(new GUIContent(variableTypeName), false, AddVariable, index);
            index++;
        }        

        return menu;

    }

  
}
