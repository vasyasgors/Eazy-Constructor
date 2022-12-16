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
    private SerializedProperty keyboaedEventHandlers;

    void OnEnable()
    {
        keyboaedEventHandlers = serializedObject.FindProperty("KeyboardEventHandlers");
    }



    public override void OnInspectorGUI()
    {


        logic = target as Logic;

        for (int i = 0; i < keyboaedEventHandlers.arraySize; i++)
        {
            EditorGUILayout.PropertyField(keyboaedEventHandlers.GetArrayElementAtIndex(i));

            Rect rect = GUILayoutUtility.GetLastRect();
            rect.x = rect.width - 50;
            rect.width = 50;
            rect.height = 15;

            if (GUI.Button(rect, new GUIContent("x")))
            {



                Debug.Log(i);
                  logic.RemoveEventHandler(i);
                


            }

            EditorGUILayout.Space();
      
        }

        if (GUILayout.Button(new GUIContent("Add Event")))
        {
           logic.AddEventHandler( new KeyboardEventHandler(KeyCode.A, EventType.KeyDown, keyboaedEventHandlers.arraySize) );

        //    Debug.Log( logic.EventHandlers[0].GetType() + " " + logic.EventHandlers[0].Type);
        }

        if (GUILayout.Button(new GUIContent("Clear Events")))
        {
            logic.ClearEventHandlers();
        }



    }

}
