using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;

// Добавить бокс
[CustomPropertyDrawer(typeof(ActionBase), true)]
public class ActionDrawer : PropertyDrawer
{

    private int propertyFieldHeight;

    // Рассчитать высоту
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {

        var data = property.objectReferenceValue as ActionBase;
        SerializedObject serializedObject = new SerializedObject(data);

        SerializedProperty prop = serializedObject.GetIterator();

        // Get heigth
        propertyFieldHeight = 0;

        if (prop.NextVisible(true))
        {
            do
            {
                if (prop.name == "m_Script") continue;

                if (prop.name == "condition")
                {
                    bool isActive = prop.FindPropertyRelative("isActive").boolValue;

                    if (isActive == true)
                    {
                        propertyFieldHeight += 50;
                    }
                }
                else
                {
                    propertyFieldHeight += 20;
                }

            } while (prop.NextVisible(false));
        }


        return base.GetPropertyHeight(property, label) + propertyFieldHeight + 10;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var data = property.objectReferenceValue as ActionBase;


      

        SerializedObject serializedObject = new SerializedObject(data);
        SerializedProperty prop = serializedObject.GetIterator();


        // Нужно нарисовать 2 бокса разных цветов
        GUI.backgroundColor = Color.white;
        Rect boxRect = new Rect(position.x - 4, position.y, position.width + 8, position.height);

        GUI.Box(boxRect, GUIContent.none);

        Rect rect = position;
        rect.height = 15;

        EditorGUI.LabelField(rect, new GUIContent(data.GetType().Name.Replace("Action", "")), EditorStyles.boldLabel);

        // Horizontal line
        Rect rectLine = new Rect(position.x - 4, position.y + 20, position.width + 8, 1);
        EditorGUI.DrawRect(rectLine, Color.black);

     

        rect.y += 30;

        if (prop.NextVisible(true))
        {
            do
            {
                if (prop.name == "m_Script") continue;

                if (prop.name == "condition")
                {
                    bool isActive = prop.FindPropertyRelative("isActive").boolValue;

                    if (isActive == true)
                    {
                        EditorGUI.PropertyField(rect, prop);
                        rect.y += 45;
                    }


                }
                else
                {
                    EditorGUI.PropertyField(rect, prop);
                    rect.y += 20;
                }

              




            } while (prop.NextVisible(false));
        }

        serializedObject.ApplyModifiedProperties();
    }


    





}
