using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System;

using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;

[CustomEditor(typeof(EventHandler))]
public class EventHandlerEditor : Editor
{
    

    EventHandler eventHandler;



    public override void OnInspectorGUI()
    {


        eventHandler = target as EventHandler;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("type"));


        if (eventHandler.type == EventHandler.EventType.OnKey)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("keyCode"));

        if (eventHandler.type == EventHandler.EventType.OnMoseDown)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("MouseButtonNumber"));

        if (eventHandler.type == EventHandler.EventType.OnTriggerEnter)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("activateTag"));

        

        EditorGUILayout.PropertyField(serializedObject.FindProperty("container"));

        serializedObject.ApplyModifiedProperties();

    }

}
