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
    private Type cachedType;
       

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + 15 * 2;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position.height = 15;

        nameProperty = property.FindPropertyRelative("name");
        typeProperty = property.FindPropertyRelative("type");


        intProperty = property.FindPropertyRelative("intValue");
        floatProperty = property.FindPropertyRelative("floatValue");
        boolProperty = property.FindPropertyRelative("boolValue");
        stringProperty = property.FindPropertyRelative("stringValue");
        colorProperty = property.FindPropertyRelative("colorValue");
        vector2Property = property.FindPropertyRelative("vector2Value");
        vector3Property = property.FindPropertyRelative("vector3Value");
        objectProperty = property.FindPropertyRelative("objectValue");

        nameProperty.stringValue = EditorGUI.TextField(position, "Variable Name", nameProperty.stringValue);

        position.y += 15;


        if(cachedType == null)
            cachedType = Variable.GetType(typeProperty.stringValue);

        if(cachedType != null)
        {
            if(cachedType.IsSubclassOf(typeof(Object) ) == true) objectProperty.objectReferenceValue = EditorGUI.ObjectField(position, objectProperty.objectReferenceValue, cachedType, true);

            if(cachedType == typeof(int)) intProperty.intValue = EditorGUI.IntField(position, intProperty.intValue );
            if(cachedType == typeof(float)) floatProperty.floatValue = EditorGUI.FloatField(position, floatProperty.floatValue );
            if(cachedType == typeof(bool)) boolProperty.boolValue = EditorGUI.Toggle(position, boolProperty.boolValue);
            if(cachedType == typeof(string)) stringProperty.stringValue = EditorGUI.TextField(position, stringProperty.stringValue);
            if(cachedType == typeof(Color)) colorProperty.colorValue = EditorGUI.ColorField(position, colorProperty.colorValue );
            if(cachedType == typeof(Vector2)) vector2Property.vector2Value = EditorGUI.Vector2Field(position,  GUIContent.none, vector2Property.vector2Value );
            if(cachedType == typeof(Vector3)) vector3Property.vector3Value = EditorGUI.Vector3Field(position, GUIContent.none, vector3Property.vector3Value );
        }


        property.serializedObject.ApplyModifiedProperties();
    }


   
}
