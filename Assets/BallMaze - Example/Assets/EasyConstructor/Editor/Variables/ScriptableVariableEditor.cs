using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using Object = UnityEngine.Object;

[CustomEditor(typeof(ScriptableVariable), true)]
public class ScriptableVariableEditor : Editor
{
    private SerializedProperty valueField;
    private VariableTypes variableType;

    private void OnEnable()
    {
        valueField = serializedObject.FindProperty("value");

        if (target is NumberVariable) (target as NumberVariable).Variable.type = VariableTypes.Number;
        if (target is ToggleVariable) (target as ToggleVariable).Variable.type = VariableTypes.Toggle;
        if (target is StringVariable) (target as StringVariable).Variable.type = VariableTypes.String;

        variableType = (target as ScriptableVariable).Variable.type;

        serializedObject.ApplyModifiedProperties();
    }

    public override void OnInspectorGUI()
    {
        (target as ScriptableVariable).Variable.name = name;

        Type realType = Variable.GetRealVariableType((VariableTypes) serializedObject.FindProperty("Variable").FindPropertyRelative("type").enumValueIndex);


        if (Application.isPlaying == true)
        {
            if(variableType == VariableTypes.Number) EditorGUILayout.FloatField((float) (target as NumberVariable).Variable.Value);
            if(variableType == VariableTypes.Toggle) EditorGUILayout.Toggle((bool) (target as ToggleVariable).Variable.Value);
            if(variableType == VariableTypes.String) EditorGUILayout.TextField((string) (target as StringVariable).Variable.Value);
        }

        if (Application.isPlaying == false)
        {
            if (variableType == VariableTypes.Number) valueField.floatValue = EditorGUILayout.FloatField(valueField.floatValue);
            if (variableType == VariableTypes.Toggle) valueField.boolValue = EditorGUILayout.Toggle(valueField.boolValue);
            if (variableType == VariableTypes.String) valueField.stringValue = EditorGUILayout.TextField(valueField.stringValue);
        }

        serializedObject.ApplyModifiedProperties();
           
    }
}


