using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using Object = UnityEngine.Object;
using System.Linq;

public static class FieldUtility
{
    public static Type GetTargetType(FieldInfo fieldInfo, SerializedProperty property)
    {
        var obj = fieldInfo.GetValue(property.serializedObject.targetObject);

        if (obj == null) return null;

        Type type = obj.GetType();

        Debug.Log(type);

        if (type.IsArray == true)
            type = type.GetElementType();

        if (type.IsGenericType == true)
            type = type.GetGenericArguments().Single();

        return type;
    }

    // Нужно доделать
    public static T GetTargetFormSerializedProperty<T>(FieldInfo fieldInfo, SerializedProperty property) where T : class
    {
        var obj = fieldInfo.GetValue(property.serializedObject.targetObject);
        if (obj == null) return null;

        T target = null;


        try
        {
            if (obj.GetType().IsArray)
            {
                var index = Convert.ToInt32(new string(property.propertyPath.Where(c => char.IsDigit(c)).ToArray()));
                target = ((T[])obj)[index];
            }
            else
            {
                target = obj as T;
            }
        }
        catch
        {
            
        }
        return target;
    }


        


    public static object TypeField(Rect rect, object obj, Type type)
    {
        if (type == typeof(int)) return EditorGUI.IntField(rect, (int)obj);
        if(type == typeof(float)) return EditorGUI.FloatField(rect, (float)obj);
        if(type == typeof(double)) return EditorGUI.DoubleField(rect, (double)obj);
        if(type == typeof(bool)) return EditorGUI.Toggle(rect, (bool)obj);
        if(type == typeof(string)) return EditorGUI.TextField(rect, (string)obj);
        if(type == typeof(Vector2)) return EditorGUI.Vector2Field(rect, type.Name, (Vector2)obj);
        if(type == typeof(Vector3)) return EditorGUI.Vector3Field(rect, type.Name, (Vector3)obj);

        return EditorGUI.ObjectField(rect, GUIContent.none, obj as Object, type, true);
    }
}


