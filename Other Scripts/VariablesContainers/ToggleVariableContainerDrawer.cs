using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(ToggleVariableContainer))]
public class ToggleVariableContainerDrawer : Editor
{
    private SerializedProperty valueField;

    private void OnEnable()
    {
        valueField = serializedObject.FindProperty("value");

       // (target as ToggleVariableContainer).Variable.SetType(VariableTypeNames.Toggle);
        serializedObject.ApplyModifiedProperties();
    }

    public override void OnInspectorGUI()
    {
        bool value = valueField.boolValue;

        if (Application.isPlaying == true)
        {
          //  EditorGUILayout.Toggle((target as ToggleVariableContainer).Variable.boolValue);
        }

        if (Application.isPlaying == false)
        {
            valueField.boolValue = EditorGUILayout.Toggle(value);

            serializedObject.ApplyModifiedProperties();
        }     
    }

}
