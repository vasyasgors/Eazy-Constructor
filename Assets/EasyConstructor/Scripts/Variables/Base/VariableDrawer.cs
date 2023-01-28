using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;



[CustomPropertyDrawer(typeof(Variable), true)]
public class VariableDrawer : PropertyDrawer
{
    private const float NameFieldWidth = 300.0f;
    private const float HorizontalSpace = 20.0f;
    private const float RemoveButtonsWidth = 40.0f;


    private SerializedProperty nameProperty;
    private SerializedProperty typeProperty;
    private SerializedProperty intProperty;
    private SerializedProperty floatProperty;
    private SerializedProperty boolProperty;
    private SerializedProperty stringProperty;
    private SerializedProperty colorProperty;
    private SerializedProperty vector2Property;
    private SerializedProperty vector3Property;
    private SerializedProperty objectProperty;

       

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        nameProperty = property.FindPropertyRelative("name");
        typeProperty = property.FindPropertyRelative("typeName");

        intProperty = property.FindPropertyRelative("intValue");
        floatProperty = property.FindPropertyRelative("floatValue");
        boolProperty = property.FindPropertyRelative("boolValue");
        stringProperty = property.FindPropertyRelative("stringValue");
        colorProperty = property.FindPropertyRelative("colorValue");
        vector2Property = property.FindPropertyRelative("vector2Value");
        vector3Property = property.FindPropertyRelative("vector3Value");

        objectProperty = property.FindPropertyRelative("objectValue");

        float allWidth = position.width;
        // Draw name field
        position.width = NameFieldWidth;
        nameProperty.stringValue = EditorGUI.TextField(position, nameProperty.stringValue);

        // Draw value field
        position.x += NameFieldWidth + HorizontalSpace;
        position.width = allWidth - NameFieldWidth - HorizontalSpace - RemoveButtonsWidth;

        Type type = Variable.GetTypeByName( (VariableTypeNames) typeProperty.enumValueIndex );
   
        if (type != null)
        {
            if(type == typeof(int)) intProperty.intValue = EditorGUI.IntField(position, intProperty.intValue );
            if(type == typeof(float)) floatProperty.floatValue = EditorGUI.FloatField(position, floatProperty.floatValue );
            if(type == typeof(bool)) boolProperty.boolValue = EditorGUI.Toggle(position, boolProperty.boolValue);
            if(type == typeof(string)) stringProperty.stringValue = EditorGUI.TextField(position, stringProperty.stringValue);
            if(type == typeof(Color)) colorProperty.colorValue = EditorGUI.ColorField(position, colorProperty.colorValue );
            if(type == typeof(Vector2)) vector2Property.vector2Value = EditorGUI.Vector2Field(position,  GUIContent.none, vector2Property.vector2Value );
            if(type == typeof(Vector3)) vector3Property.vector3Value = EditorGUI.Vector3Field(position, GUIContent.none, vector3Property.vector3Value );

            if (type.IsSubclassOf(typeof(Object)) == true) objectProperty.objectReferenceValue = EditorGUI.ObjectField(position, objectProperty.objectReferenceValue, type, true);
        }

     
        // Draw remove button
        Rect buttonRect = new Rect(position.x + position.width, position.y, RemoveButtonsWidth, position.height);
        if (GUI.Button(buttonRect, new GUIContent("✖")))
        {
            property.FindPropertyRelative("ToRemove").boolValue = true;
        }


        property.serializedObject.ApplyModifiedProperties();
    }



}
