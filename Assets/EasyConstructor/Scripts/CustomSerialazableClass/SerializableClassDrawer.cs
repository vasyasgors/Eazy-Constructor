using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System;
using System.Linq;

using Object = UnityEngine.Object;
using System.Reflection;


// Сделать последовательность отображения как в юнити
// сделать отображение названий с большой буквы 

[CustomPropertyDrawer(typeof(SerializableClass), true)]
public class SerializableClassDrawer : PropertyDrawer
{

    private int fieldHeigth = 15;
    private int fieldVerticalSpace = 3;

    private string SerializationString = "serializedObject";
    private string ActionType = "type";


    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (GetNestedObject(property) == null) return base.GetPropertyHeight(property, label);

        // Этот блок важно вызывать в самом начале
        int nestedObjectFieldAmount = GetVisibleFields(GetNestedObject(property).GetType()).Length;

  
        int wrapperFieldHeigth = 0;
        SerializedProperty[] wrapperProperties = GetAdditionalSerializedPropertyWrapper(property);

        if (wrapperProperties.Length > 0)
        {
            for (int i = 0; i < wrapperProperties.Length; i++)
            {
                wrapperFieldHeigth += (int)EditorGUI.GetPropertyHeight(wrapperProperties[i]);
            }

        }


        return (fieldHeigth + fieldVerticalSpace) * nestedObjectFieldAmount + wrapperFieldHeigth;

    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    { 
        SerializableClass nestedObject = GetNestedObject(property);

        GUI.Box(position, GUIContent.none);

        SerializedProperty serializationStringProperty = property.FindPropertyRelative(SerializationString);

        if (nestedObject == null)
        {
            Debug.LogWarning("In wrapper " + property.name + " nested objcect is null");
            return;
        }

        // Draw wrapper field
        SerializedProperty[] wrapperProperties = GetAdditionalSerializedPropertyWrapper(property);

        if (wrapperProperties.Length > 0)
        {
            for (int i = 0; i < wrapperProperties.Length; i++)
            {
                position.height = EditorGUI.GetPropertyHeight(property);

                EditorGUI.PropertyField(position, property);

                position.y += position.height + fieldVerticalSpace;
            }

        }

        // Draw field serialized class
        FieldInfo[] allField = GetVisibleFields(nestedObject.GetType());

        for (int i = 0; i < allField.Length; i++)
        {
            position.height = fieldHeigth;

            object fieldValue = EditorGUIExtension.FieldFieldInfo( position, allField[i], allField[i].GetValue(nestedObject), allField[i].FieldType, new GUIContent(allField[i].Name));

            if (fieldValue != null) allField[i].SetValue(nestedObject, fieldValue);

            position.y = position.y + fieldHeigth + fieldVerticalSpace;
        }

        string serialize = SerializableClassWrapper.Serialize(nestedObject);
        serializationStringProperty.stringValue = serialize;
        serializationStringProperty.serializedObject.ApplyModifiedProperties();
    }

    private SerializedProperty[] GetAdditionalSerializedPropertyWrapper(SerializedProperty property)
    {
        List<SerializedProperty> allSerializedProperty = new List<SerializedProperty>();

        // Сделать без Try а условием
        try
        {
            SerializedProperty endProperty = property.GetEndProperty();

           
            while (property.NextVisible(true))
            {

                Debug.Log(property.name);

                /*
                if (property.name == endProperty.name) break;

                if (property.name == "serializedObject") continue;
                if (property.name == "type") continue;
                if (property.name == "data") continue;

                allSerializedProperty.Add(property);*/
            }
            
        }
        catch { }

        return allSerializedProperty.ToArray();

    }

    private FieldInfo[] GetVisibleFields(Type type)
    {
        List<FieldInfo> fields = new List<FieldInfo>(5);

        FieldInfo[] allField = type.GetFields();

        for (int i = 0; i < allField.Length; i++)
        {
            object[] customAttributes = allField[i].GetCustomAttributes(false);

            if (customAttributes.Contains(new HideInInspector())) continue;

            fields.Add(allField[i]);
        }

        return fields.ToArray();
    }

    private SerializableClass GetNestedObject(SerializedProperty property)
    {
        return SerializableClassWrapper.Deserialize(property.FindPropertyRelative(SerializationString).stringValue, property.FindPropertyRelative(ActionType).stringValue);
    }


}
