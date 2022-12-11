using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System;

using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;

[CustomEditor(typeof(EventHandler), true)]
public class EventHandlerEditor : Editor
{

    //private SerializedProperty conditionProperty;
    private SerializedProperty actionsProperty;

    EventHandler eventHandler;

    void OnEnable()
    {
       //conditionProperty = serializedObject.FindProperty("condition");
        actionsProperty = serializedObject.FindProperty("actions");
    }

    public override void OnInspectorGUI()
    {

      //  EditorGUILayout.PropertyField(conditionProperty);

        eventHandler = target as EventHandler;


        for (int i = 0; i <  actionsProperty.arraySize; i++)
        {
            SerializedProperty currentActionProperty = actionsProperty.GetArrayElementAtIndex(i);


            EditorGUILayout.PropertyField(currentActionProperty);


            Rect scale = GUILayoutUtility.GetLastRect();
            scale.y += 3;
            scale.x = scale.width - 70;
            scale.width = 80;
            scale.height = 15;

            if (GUI.Button(scale, "Remove"))
            {
                eventHandler.RemoveAction(currentActionProperty.objectReferenceValue as ActionBase);
            }

             scale = GUILayoutUtility.GetLastRect();
            scale.y += 3;
            scale.x = scale.width - 70 - 85;
            scale.width = 80;
            scale.height = 15;

            if (GUI.Button(scale, "Condition"))
            {
                eventHandler.ToogleActiveCondition(currentActionProperty.objectReferenceValue as ActionBase);
            }
        }


        Rect menuRect = EditorGUILayout.GetControlRect();

        if (EditorGUI.DropdownButton(menuRect, new GUIContent("Add Action"), FocusType.Passive))
        {
            BuildAddActionMenu().DropDown(menuRect);

        }

        Repaint();
    }
    

    private void AddAction(object name)
    {

        if(name.ToString() == "Destory Object")
            eventHandler.AddAction<DestoryAction>();

        if (name.ToString() == "Spawn Object")
            eventHandler.AddAction<SpawnAction>();

        if (name.ToString() == "Load Level")
            eventHandler.AddAction<LoadLevelAction>();

    

    }


    private GenericMenu BuildAddActionMenu()
    {
        GenericMenu menu = new GenericMenu();

        menu.AddItem(new GUIContent("Destory Object"), false, AddAction, "Destory Object");
        menu.AddItem(new GUIContent("Spawn Object"), false, AddAction, "Spawn Object");
        menu.AddItem(new GUIContent("Load Level"), false, AddAction, "Load Level");


        return menu;

    }

}
