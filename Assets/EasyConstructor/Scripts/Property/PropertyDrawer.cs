using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(PropertyBase), true)]
public class PropertyEditorDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        PropertyDrawMode mode = (PropertyDrawMode)property.FindPropertyRelative("drawMode").enumValueIndex;

        if (mode == PropertyDrawMode.Setup)
        {
            DrawSetupProperty(position, property);
        }

        if (mode == PropertyDrawMode.OnlyValue)
        {
            DrawOnlyValueProperty(position, property, label);
        }

        if (mode == PropertyDrawMode.Linked)
        {
            DrawLinkedProperty(position, property);
        }
    }

    private void DrawSetupProperty(Rect position, SerializedProperty property)
    {
        Rect nameRect = position;
        nameRect.width *= 0.3f;

        Rect valueRect = position;
        valueRect.width *= 0.7f;
        valueRect.x += nameRect.width;

        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("Name"), GUIContent.none);
        EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("Value"), GUIContent.none);
    }

    private void DrawOnlyValueProperty(Rect position, SerializedProperty property, GUIContent lable)
    {

        EditorGUI.PropertyField(position, property.FindPropertyRelative("Value"), GUIContent.none);
    }

    private void DrawLinkedProperty(Rect position, SerializedProperty property)
    {
        string name = property.FindPropertyRelative("Name").stringValue;
        string value = property.FindPropertyRelative("Value").floatValue.ToString();


        EditorGUI.LabelField(position, name + ": " + value + " ");
    }
}
