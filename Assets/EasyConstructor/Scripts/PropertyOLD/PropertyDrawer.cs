using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace PropertyOld
{

    [CustomPropertyDrawer(typeof(PropertyBase), true)]
    public class PropertyEditorDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.width -= 60;

            SerializedProperty drawModeProperty = property.FindPropertyRelative("drawMode");
            PropertyDrawMode mode = (PropertyDrawMode)drawModeProperty.enumValueIndex;

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


            position.x += position.width;
            position.width = 60;


            if (GUI.Button(position, "↕"))
            {

                if (mode == PropertyDrawMode.OnlyValue)
                    drawModeProperty.enumValueIndex = (int)PropertyDrawMode.Linked;

                if (mode == PropertyDrawMode.Linked)
                    drawModeProperty.enumValueIndex = (int)PropertyDrawMode.OnlyValue;
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
            EditorGUI.PropertyField(position, property.FindPropertyRelative("Value"), lable);

        }

        private void DrawLinkedProperty(Rect position, SerializedProperty property)
        {
            string name = property.FindPropertyRelative("Name").stringValue;

            string value = "";

            Type type = fieldInfo.GetValue(property.serializedObject.targetObject).GetType();

            if (type == typeof(PInt)) value = property.FindPropertyRelative("Value").intValue.ToString();
            if (type == typeof(PFloat)) value = property.FindPropertyRelative("Value").floatValue.ToString();
            if (type == typeof(PBool)) value = property.FindPropertyRelative("Value").boolValue.ToString();
            if (type == typeof(PVector2)) value = property.FindPropertyRelative("Value").vector2Value.ToString();
            if (type == typeof(PVector3)) value = property.FindPropertyRelative("Value").vector3Value.ToString();
            if (type == typeof(PObject)) value = property.FindPropertyRelative("Value").objectReferenceValue.ToString();
            if (type == typeof(PGameObject)) value = property.FindPropertyRelative("Value").objectReferenceValue.ToString();


            EditorGUI.LabelField(position, name + ": " + value + " ");
        }
    }
}
