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

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + 15 * 3;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position.height = 15;

        SerializedProperty nameProperty = property.FindPropertyRelative("name");
        SerializedProperty typeProperty = property.FindPropertyRelative("type");
        SerializedProperty unityOjbect = property.FindPropertyRelative("unityObject");
        SerializedProperty otherObject = property.FindPropertyRelative("otherObject");


  

        nameProperty.stringValue = EditorGUI.TextField(position, "Variable Name", nameProperty.stringValue);

        position.y += 15;
        typeProperty.stringValue = EditorGUI.TextField(position, "Type", typeProperty.stringValue);

        position.y += 15;

        Type t = Variable.GetType(typeProperty.stringValue);

        if(t != null)
        {
            if(t.IsSubclassOf(typeof(Object) ) == true)
            {
                unityOjbect.objectReferenceValue = EditorGUI.ObjectField(position, unityOjbect.objectReferenceValue, t, true);
            }

            if(t == typeof(int))
            {
                otherObject.intValue = EditorGUI.IntField(position,  otherObject.intValue );
            }
        }


        property.serializedObject.ApplyModifiedProperties();

        Debug.Log(t);
    }


   
}
