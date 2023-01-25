using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;


public static  class EditorGUIExtension
{
    public static object FieldFieldInfo(Rect position, FieldInfo fieldInfo, object value, GUIContent lable)
    {
        // Нужно сначала это
        if (fieldInfo.FieldType.IsSubclassOf(typeof(Object)))
            return EditorGUI.ObjectField(position, new GUIContent(fieldInfo.Name), value as Object, fieldInfo.FieldType, true);

        // Это должно быть вторым
        if (value.GetType() == typeof(string))
        {
            if (value == null)
                return "";

            return EditorGUI.TextField(position, lable, (string)value);
        }

        if (value == null) return null;

        if (value.GetType() == typeof(int))
            return EditorGUI.IntField(position, lable, (int)value);

        if (value.GetType() == typeof(float))
            return EditorGUI.FloatField(position, lable, (float)value);

        if (value.GetType() == typeof(bool))
            return EditorGUI.Toggle(position, lable, (bool)value);

      

        if (value.GetType() == typeof(Vector2))
            return EditorGUI.Vector2Field(position, lable, (Vector2)value);

        if (value.GetType() == typeof(Vector2Int))
            return EditorGUI.Vector2Field(position, lable, (Vector2Int)value);

        if (value.GetType() == typeof(Vector3))
            return EditorGUI.Vector3Field(position, lable, (Vector3)value);

        if (value.GetType() == typeof(Vector3Int))
            return EditorGUI.Vector3Field(position, lable, (Vector3Int)value);

        if (value.GetType() == typeof(Color))
            return EditorGUI.ColorField(position, lable, (Color)value);

        if (value.GetType().IsEnum == true)
            return EditorGUI.EnumPopup(position, lable, (Enum)Enum.Parse(value.GetType(), value.ToString()));

     

        // Надо подумать, как вызывать драверы для кастомных полей

        if (value.GetType().IsSubclassOf( typeof(PropertyBase)) == true)
            return PropertyField(position, fieldInfo, value, lable);

        if (value.GetType().IsSubclassOf(typeof(Variable)) == true)
            return VariableField(position, fieldInfo, value, lable);

        Debug.LogWarning("Type field is " + value.GetType() + " impossible drawed!");

        // throw new InvalidCastException();

        return null;
    }



    private static object VariableField(Rect position, FieldInfo fieldInfo, object obj, GUIContent lable)
    {
        FieldInfo nameField = obj.GetType().BaseType.GetField("Name");
        FieldInfo valueField = obj.GetType().BaseType.GetField("Value");

        position.width *= 0.5f;

        object nameObject = nameField.GetValue(obj);

        if (nameObject == null) nameObject = "";

        nameField.SetValue(obj,  FieldFieldInfo(position, nameField, nameObject, GUIContent.none) );

        position.x += position.width;


        GUI.Label(position, new GUIContent("Тут будет значение переменной по имени"));
       // valueField.SetValue(obj,  FieldFieldInfo(position, valueField, valueField.GetValue(obj), GUIContent.none) );

    

        return obj;
    }

    private static object PropertyField(Rect position, FieldInfo fieldInfo, object obj, GUIContent lable)
    {
        position.width -= 40;

        FieldInfo modeField = obj.GetType().GetField("mode");

        // Тут Base тип использовать так себе
        FieldInfo valueField = obj.GetType().BaseType.GetField("value", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo variabledField = obj.GetType().BaseType.GetField("variable", BindingFlags.NonPublic | BindingFlags.Instance);

        PropertyMode mode = (PropertyMode) modeField.GetValue(obj);

        if (mode == PropertyMode.Value)
        {
            object valueValue = FieldFieldInfo(position, valueField, valueField.GetValue(obj), lable);
            valueField.SetValue(obj, valueValue);
        }


        if (mode == PropertyMode.Variable)
        {

            object variableValue;

            if (variabledField.GetValue(obj) == null)
                variableValue = Activator.CreateInstance(variabledField.FieldType) as object;
            else
                variableValue = variabledField.GetValue(obj);

            variableValue = FieldFieldInfo( position, valueField, variableValue, lable);

            variabledField.SetValue(obj, variableValue);

        }

        position.x += position.width;
        position.width = 40;


        if (GUI.Button(position, "↕"))
        {

            if (mode == PropertyMode.Value)
                modeField.SetValue(obj, (int)PropertyMode.Variable);

            if (mode == PropertyMode.Variable)
                modeField.SetValue(obj, (int)PropertyMode.Value);
            
        }



        return obj;
    }
}
