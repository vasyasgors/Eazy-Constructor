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
        position.width -= 40;
    
        SerializedProperty drawModeProperty = property.FindPropertyRelative("mode");
        PropertyMode mode = (PropertyMode)drawModeProperty.enumValueIndex;

        if (mode == PropertyMode.Value)
        {
            EditorGUI.PropertyField(position, property.FindPropertyRelative("value"), label);
        }


        if (mode == PropertyMode.Variable)
        {

            // Сделать отображение так, чтобы была ссылка и на переменную и отображалась значение переменной
            EditorGUI.ObjectField(position, property.FindPropertyRelative("variable"), label);



        }


        position.x += position.width;
        position.width = 40;


        if (GUI.Button(position, "↕"))
        {

            if (mode == PropertyMode.Value)
                drawModeProperty.enumValueIndex = (int)PropertyMode.Variable;

            if (mode == PropertyMode.Variable)
            {
                drawModeProperty.enumValueIndex = (int)PropertyMode.Value;

                // Обнуляем переменную чтобы бралось значение из установленного в эдиторе
                // Обнулять не удобно
               // property.FindPropertyRelative("variable").objectReferenceValue = null;

                //property.serializedObject.ApplyModifiedProperties();
            }
        }



    }

}

