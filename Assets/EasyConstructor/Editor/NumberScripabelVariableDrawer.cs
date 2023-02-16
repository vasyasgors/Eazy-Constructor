using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

// Сделать изменения глобальных переменных в ранТайме
[CustomEditor(typeof(NumberScripabelVariable))]
public class NumberScripabelVariableDrawer : Editor
{
    private SerializedProperty valueField;

    private void OnEnable()
    {
        valueField = serializedObject.FindProperty("value");

        (target as NumberScripabelVariable).Variable.type = VariableTypes.Number;
        serializedObject.ApplyModifiedProperties();
    }

    public override void OnInspectorGUI()
    {
        (target as NumberScripabelVariable).Variable.name = name;

        float value = valueField.floatValue;

        if (Application.isPlaying == true)
        {
            EditorGUILayout.FloatField((float) (target as NumberScripabelVariable).Variable.Value);
        }

        if (Application.isPlaying == false)
        {
            valueField.floatValue = EditorGUILayout.FloatField(value);

            serializedObject.ApplyModifiedProperties();
        }     
    }

}
