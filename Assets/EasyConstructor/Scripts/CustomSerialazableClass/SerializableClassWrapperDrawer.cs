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

[CustomPropertyDrawer(typeof(SerializableClassWrapper), true)]
public class SerializableClassWrapperDrawer : PropertyDrawer
{

    private int fieldHeigth = 16;
    private int fieldVerticalSpace = 3;

    private string SerializationString = "serializedObject";
    private string ActionType = "type";


    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (GetNestedObject(property) == null) return base.GetPropertyHeight(property, label);

        int fieldAmount = GetNestedObject(property).GetType().GetFields().Length;

        // Вынести в отдельный метод
        int additionHeight = 0;
        if (property.NextVisible(true))
        {
            do
            {

                if (property.name == "serializedObject") continue;
                if (property.name == "type") continue;
                if (property.name == "data") continue;

                additionHeight += (int) EditorGUI.GetPropertyHeight(property) + fieldVerticalSpace;

            } while (property.NextVisible(false));
        }

        // Странно почему без fieldVerticalSpace работает хорошо 
        return base.GetPropertyHeight(property, label) + (fieldHeigth ) * fieldAmount + additionHeight;

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

        // Draw other prop

        SerializedProperty endProperty = property.GetEndProperty();

        if (property.NextVisible(true))
        {
            do
            {
                if (property.name == endProperty.name) break;
                if (property.name == "serializedObject") continue;
                if (property.name == "type") continue;
                if (property.name == "data") continue;

                

               // Debug.Log(property.name);

                position.height = EditorGUI.GetPropertyHeight(property);


              //  Debug.Log(property.name);
                EditorGUI.PropertyField(position, property);

                position.y += position.height + fieldVerticalSpace;

            } while (property.NextVisible(false));
        }

        FieldInfo[] allField = nestedObject.GetType().GetFields();

        for (int i = 0; i < allField.Length; i++)
        {
            position.height = fieldHeigth;

           // Debug.Log(allField[i].GetValue(nestedObject) + " " + allField[i].Name);


            object fieldValue = EditorGUIExtension.FieldFieldInfo( position, allField[i], allField[i].GetValue(nestedObject), new GUIContent(allField[i].Name));

            if (fieldValue != null) allField[i].SetValue(nestedObject, fieldValue);

            position.y = position.y + fieldHeigth + fieldVerticalSpace;
        }


        

        string serialize = SerializableClassWrapper.Serialize(nestedObject);
        serializationStringProperty.stringValue = serialize;
        serializationStringProperty.serializedObject.ApplyModifiedProperties();

      
 
        

      
    }


    private SerializableClass GetNestedObject(SerializedProperty property)
    {
        return SerializableClassWrapper.Deserialize(property.FindPropertyRelative(SerializationString).stringValue, property.FindPropertyRelative(ActionType).stringValue);
    }


}
