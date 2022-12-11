using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System;

using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;

[CustomEditor(typeof(Logic))]
public class LogicEditor : Editor
{

    Logic logic;

    private SerializedProperty eventHandlersProperty;

    SerializedProperty propAction;

    public override void OnInspectorGUI()
    {
        eventHandlersProperty = serializedObject.FindProperty("eventHandlers");


        for (int i = 0; i < eventHandlersProperty.arraySize; i++)
        {
            SerializedProperty serializedProperty = eventHandlersProperty.GetArrayElementAtIndex(i);

            propAction = serializedProperty.serializedObject.FindProperty("actions");

      

         

            for (int j = 0; j < propAction.arraySize; j++)
            {
                SerializedProperty prop = propAction.GetArrayElementAtIndex(j);

                EditorGUILayout.PropertyField(serializedProperty);
            }

         
        }

        logic = target as Logic;

        Rect menuRect = EditorGUILayout.GetControlRect();

        if (EditorGUI.DropdownButton(menuRect, new GUIContent("Add Event"), FocusType.Passive))
        {
            BuildAddActionMenu().DropDown(menuRect);
        }
    }

    private void AddAction(object name)
    {
        if (name.ToString() == "Spawn")
            logic.AddEventHandler<EventHandler>();

        if (name.ToString() == "Every Frame")
            logic.AddEventHandler<EventHandler>();

        if (name.ToString() == "Destory")
            logic.AddEventHandler<EventHandler>();

    }


    private GenericMenu BuildAddActionMenu()
    {
        GenericMenu menu = new GenericMenu();

        menu.AddItem(new GUIContent("Spawn"), false, AddAction, "Spawn");
        menu.AddItem(new GUIContent("Every Frame"), false, AddAction, "Every Frame");
        menu.AddItem(new GUIContent("Destory"), false, AddAction, "Destory");


        return menu;

    }

}
