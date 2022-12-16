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
        keyboaedEventHandlers = serializedObject.FindProperty("KeyboardHandlers");
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

        Rect menuRect = EditorGUILayout.GetControlRect();

        if (EditorGUILayout.DropdownButton(new GUIContent("Add Event"), FocusType.Passive))
        {

            BuildAddEventHandlersMenu().DropDown(menuRect);
        }

        if (GUILayout.Button(new GUIContent("Clear Events")))
        {
            logic.ClearEventHandlers();
        }



    }


    public void AddEventHandler()
    {
        //Activator.CreateInstance(typeof(KeyboardEventHandler));
    }

    public GenericMenu BuildAddEventHandlersMenu()
    {
        GenericMenu menu = new GenericMenu();

        foreach (int i in Enum.GetValues(typeof(KeyCode)))
        {
            menu.AddItem(new GUIContent(((KeyCode)i).ToString()), false, AddEventHandler);
        }

        return menu;
    }

}
