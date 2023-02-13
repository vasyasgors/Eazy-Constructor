using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(AssignNumberVariable))]
public class AssignVariableDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Debug.Log("AssignVariableDrawer");
    }
}
