using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;




// Добавить бокс
// Переключение отображение условия должно быть тут, ВОЗМОЖНо
[CustomPropertyDrawer(typeof(ActionWrapper), true)]
public class ActionContainerDrawer : PropertyDrawer
{



    // Рассчитать высоту
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {

      
        return base.GetPropertyHeight(property, label) + 100;
      
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ActionBase action = ActionWrapper.DeserializeAction(property.FindPropertyRelative("serialazableString").stringValue, property.FindPropertyRelative("type").stringValue);

        if (action == null) return;


        Type type = action.GetType();



        FieldInfo[] allField = type.GetFields();

        position.height = 15;

        for (int i = 0; i < allField.Length; i++)
        {

            allField[i].SetValue(action,      DrawFieldByField(position, allField[i], allField[i].GetValue(action)) );

            position.y += 20;
        }


        string serialize = ActionWrapper.SerializeAction(action);

        property.FindPropertyRelative("serialazableString").stringValue = serialize;

        property.serializedObject.ApplyModifiedProperties();
    }


    private object DrawFieldByField(Rect position, FieldInfo fieldInfo, object value)
    {


        if (fieldInfo.FieldType == typeof(GameObject)) return EditorGUI.ObjectField(position, new GUIContent(fieldInfo.Name), value as GameObject, fieldInfo.FieldType, true);
        if (fieldInfo.FieldType == typeof(Transform)) return EditorGUI.ObjectField(position, new GUIContent(fieldInfo.Name), value as Transform, fieldInfo.FieldType, true);
        if (fieldInfo.FieldType == typeof(Material)) return EditorGUI.ObjectField(position, new GUIContent(fieldInfo.Name), value as Material, fieldInfo.FieldType, true);
        if (fieldInfo.FieldType == typeof(Material)) return EditorGUI.ObjectField(position, new GUIContent(fieldInfo.Name), value as Material, fieldInfo.FieldType, true);

        if (fieldInfo.FieldType == typeof(int)) return EditorGUI.IntField(position, new GUIContent(fieldInfo.Name), (int) value);
        if (fieldInfo.FieldType == typeof(float)) return EditorGUI.FloatField(position, new GUIContent(fieldInfo.Name), (float) value);
        if (fieldInfo.FieldType == typeof(bool)) return EditorGUI.Toggle(position, new GUIContent(fieldInfo.Name), (bool) value);
        if (fieldInfo.FieldType == typeof(string)) return EditorGUI.TextField(position, new GUIContent(fieldInfo.Name), (string) value);

        return null;
    }








}
