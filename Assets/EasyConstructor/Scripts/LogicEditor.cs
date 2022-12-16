using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System;

using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;

[CustomEditor(typeof(Logic), true)]
public class LogicEditor : Editor
{


    private Logic logic;
    private SerializedProperty events;

    void OnEnable()
    {
        events = serializedObject.FindProperty("KeyboardEventHandlers");
    }



    public override void OnInspectorGUI()
    {


        logic = target as Logic;

        for (int i = 0; i < events.arraySize; i++)
        {
            EditorGUILayout.PropertyField(events.GetArrayElementAtIndex(i));
            EditorGUILayout.Space();
      
        }

        if (GUILayout.Button(new GUIContent("Add Event")))
        {
           logic.AddEventHandler( new KeyboardEventHandler(KeyCode.A, EventType.KeyDown) );

        //    Debug.Log( logic.EventHandlers[0].GetType() + " " + logic.EventHandlers[0].Type);
        }

        if (GUILayout.Button(new GUIContent("Clear Events")))
        {
            logic.ClearEventHandlers();
        }



    }

}
