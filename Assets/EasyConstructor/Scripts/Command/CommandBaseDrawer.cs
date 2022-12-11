using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;

// Добавить бокс
[CustomPropertyDrawer(typeof(CommandBase), true)]
public class CommandBaseDrawer : PropertyDrawer
{
    
    // Рассчитать высоту
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + 100;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var data = property.objectReferenceValue as CommandBase;

        SerializedObject serializedObject = new SerializedObject(data);

        SerializedProperty prop = serializedObject.GetIterator();

        Rect rect = position;
        rect.height -= 100;

        if (prop.NextVisible(true))
        {
            do
            {
                if (prop.name == "m_Script") continue;

                EditorGUI.PropertyField(rect, prop);

                rect.y += 20;

            } while (prop.NextVisible(false));
        }

        serializedObject.ApplyModifiedProperties();




    }






}
