using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;


[CustomPropertyDrawer(typeof(PropertyBase), true)]
public class PropertyEditorDrawer : PropertyDrawer
{
    private const string ModePropertyName = "mode";
    private const string VariableNamePropertyName = "variableName";
    private const string ValueNamePropertyName = "value";

    private const float WidthChangeModeButton = 40.0f;

    private SerializedProperty drawModeProperty;
    private SerializedProperty variableNameProperty;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
   
        drawModeProperty = property.FindPropertyRelative(ModePropertyName);
        variableNameProperty = property.FindPropertyRelative(VariableNamePropertyName);

        PropertyMode mode = (PropertyMode)drawModeProperty.enumValueIndex;

        // Draw Property
        position.width -= WidthChangeModeButton;

        if (mode == PropertyMode.Value)
        {
            EditorGUI.PropertyField(position, property.FindPropertyRelative(ValueNamePropertyName), label);
        }

        if (mode == PropertyMode.Variable)
        {
            Color prevColor = GUI.backgroundColor;
            GUI.backgroundColor = VariableDrawer.VariableNameBackgroundColor;

            variableNameProperty.stringValue =  EditorGUI.TextField(position, label, variableNameProperty.stringValue);

            GUI.backgroundColor = prevColor;
        }

        // Draw change mode button
        position.x += position.width;
        position.width = WidthChangeModeButton;

        if (GUI.Button(position, "V"))
        {

            if (mode == PropertyMode.Value)
                drawModeProperty.enumValueIndex = (int)PropertyMode.Variable;

            if (mode == PropertyMode.Variable)
                drawModeProperty.enumValueIndex = (int)PropertyMode.Value;
        }

        variableNameProperty.serializedObject.ApplyModifiedProperties();

    }


}
