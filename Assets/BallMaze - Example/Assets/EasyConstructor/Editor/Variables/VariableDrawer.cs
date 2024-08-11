using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;


// Сделать отображение значения переменных в реальном времени
[CustomPropertyDrawer(typeof(Variable), true)]
public class VariableDrawer : PropertyDrawer
{
    public static Color VariableNameBackgroundColor = new Color(0.9f, 0.9f, 0.9f);

    private const float NameFieldWidth = 300.0f;
    private const float HorizontalSpace = 20.0f;
    private const float RemoveButtonsWidth = 40.0f;


    private SerializedProperty nameProperty;
    private SerializedProperty typeProperty;

    private SerializedProperty floatProperty;
    private SerializedProperty boolProperty;
    private SerializedProperty stringProperty;
    private SerializedProperty objectProperty;

       

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        nameProperty = property.FindPropertyRelative("name");
        typeProperty = property.FindPropertyRelative("type");

        floatProperty = property.FindPropertyRelative("floatValue");
        boolProperty = property.FindPropertyRelative("boolValue");
        stringProperty = property.FindPropertyRelative("stringValue");
        objectProperty = property.FindPropertyRelative("objectValue");

        float allWidth = position.width;

        // Draw name field
        Color prevColor = GUI.backgroundColor;
        GUI.backgroundColor = VariableNameBackgroundColor;

        position.width = NameFieldWidth;

        // Тестовый режим, убираем границу
        // GUIStyle s = new GUIStyle();
        //s.border = new RectOffset();
        nameProperty.stringValue = EditorGUI.TextField(position, nameProperty.stringValue);//, s);
        GUI.backgroundColor = prevColor;


        // Draw value field
        position.x += NameFieldWidth + HorizontalSpace;
        position.width = allWidth - NameFieldWidth - HorizontalSpace - RemoveButtonsWidth;
        

        // В отдельный метод
        Type type = Variable.GetRealVariableType( (VariableTypes) typeProperty.enumValueIndex );

        if (type != null)
        {
            if(type == typeof(float)) floatProperty.floatValue = EditorGUI.FloatField(position, floatProperty.floatValue);
            if(type == typeof(bool)) boolProperty.boolValue = EditorGUI.Toggle(position, boolProperty.boolValue);
            if(type == typeof(string)) stringProperty.stringValue = EditorGUI.TextField(position, stringProperty.stringValue);

            if (type.IsSubclassOf(typeof(Object)) == true) objectProperty.objectReferenceValue = EditorGUI.ObjectField(position, objectProperty.objectReferenceValue, type, true);
        }

     
        // Убрать от седова !!!!
        // Draw remove button
        Rect buttonRect = new Rect(position.x + position.width, position.y, RemoveButtonsWidth, position.height);
        if (GUI.Button(buttonRect, new GUIContent("✖")))
        {
            property.FindPropertyRelative("ToRemove").boolValue = true;
        }
     

        property.serializedObject.ApplyModifiedProperties();
    }



}
