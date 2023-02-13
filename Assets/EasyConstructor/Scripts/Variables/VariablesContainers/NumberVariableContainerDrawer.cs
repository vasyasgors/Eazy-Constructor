using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(NumberVariableContainer))]
public class NumberVariableContainerDrawer : Editor
{
    private SerializedProperty valueField;

    private void OnEnable()
    {
        valueField = serializedObject.FindProperty("value");

        (target as NumberVariableContainer).Variable.SetType(VariableTypeNames.Number);
        serializedObject.ApplyModifiedProperties();
    }

    public override void OnInspectorGUI()
    {
        float value = valueField.floatValue;

        if (Application.isPlaying == true)
        {
            EditorGUILayout.FloatField((target as NumberVariableContainer).Variable.floatValue);
        }

        if (Application.isPlaying == false)
        {
            valueField.floatValue = EditorGUILayout.FloatField(value);

            serializedObject.ApplyModifiedProperties();
        }     
    }

}
