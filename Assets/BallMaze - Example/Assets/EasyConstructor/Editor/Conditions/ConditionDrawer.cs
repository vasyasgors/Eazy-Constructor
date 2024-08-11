using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;

[CustomPropertyDrawer(typeof(Condition))]
public class ConditionDrawer : PropertyDrawer
{

    private SerializedProperty variablePickerProperty;
    private SerializedProperty conditionTypeProperty;
    private SerializedProperty floatPickerProperty;
    private SerializedProperty boolPickerProperty;


    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + 5;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        variablePickerProperty = property.FindPropertyRelative("firstVariablePicker");
        conditionTypeProperty = property.FindPropertyRelative("type");
        floatPickerProperty = property.FindPropertyRelative("floatPicker");
        boolPickerProperty = property.FindPropertyRelative("boolPicker");

        //  Calc Rects
        var variablePickerRect = new Rect(position.x, position.y, position.width * 0.4f, 15);
        var conditionTypeRect = new Rect(variablePickerRect.x + variablePickerRect.width, position.y, position.width * 0.2f, 15);
        var fieldPickerRect = new Rect(conditionTypeRect.x + conditionTypeRect.width, position.y, position.width * 0.4f, 15);

        VariableTypes variableType = GetCurrentVariableType(variablePickerProperty);
        ConditionType conditionType = (ConditionType)conditionTypeProperty.enumValueIndex;

        EditorGUI.PropertyField(variablePickerRect, variablePickerProperty);
        if (EditorGUI.DropdownButton(conditionTypeRect, new GUIContent(Condition.ConditionTypeToString(conditionType)), FocusType.Passive) == true)
        {
            GetConditionMenu().DropDown(conditionTypeRect);
        }


        if(variableType == VariableTypes.Any)
        {
            EditorGUI.LabelField(fieldPickerRect, "Select Variable");
        }

        if (variableType == VariableTypes.Number)
        {
            EditorGUI.PropertyField(fieldPickerRect, floatPickerProperty, GUIContent.none);

        }

        if(variableType == VariableTypes.Toggle)
        {
            EditorGUI.PropertyField(fieldPickerRect, boolPickerProperty, GUIContent.none);
        }

    }

    // Плохое место
    private VariableTypes GetCurrentVariableType(SerializedProperty variablePickerProperty)
    {
        UnityEngine.Object variablelOwner = variablePickerProperty.FindPropertyRelative("owner").objectReferenceValue;

        if(variablelOwner is Behaviour)
        {
            return  (variablelOwner as Behaviour).GetVariable(variablePickerProperty.FindPropertyRelative("variableName").stringValue).type;
        }

        if (variablelOwner is ScriptableVariable)
        {
            return (variablelOwner as ScriptableVariable).Variable.type;
        }

        return VariableTypes.Any;
    }



    private GenericMenu GetConditionMenu()
    {
        GenericMenu menu = new GenericMenu();

        menu.AddItem(new GUIContent(Condition.ConditionTypeToString(ConditionType.Equals)), false, UpdateCondition, (int) ConditionType.Equals);
        menu.AddItem(new GUIContent(Condition.ConditionTypeToString(ConditionType.NotEqual)), false, UpdateCondition, (int) ConditionType.NotEqual);
        menu.AddItem(new GUIContent(Condition.ConditionTypeToString(ConditionType.GreaterOrEqual)), false, UpdateCondition, (int) ConditionType.GreaterOrEqual);
        menu.AddItem(new GUIContent(Condition.ConditionTypeToString(ConditionType.GreaterThan)), false, UpdateCondition, (int) ConditionType.GreaterThan);
        menu.AddItem(new GUIContent(Condition.ConditionTypeToString(ConditionType.SmallerOrEqual)), false, UpdateCondition, (int) ConditionType.SmallerOrEqual);
        menu.AddItem(new GUIContent(Condition.ConditionTypeToString(ConditionType.SmallerThan)), false, UpdateCondition, (int) ConditionType.SmallerThan);

        return menu;
    }

    private void UpdateCondition(object conditionTypeIndex)
    {
        conditionTypeProperty.enumValueIndex  = (int) conditionTypeIndex;
        conditionTypeProperty.serializedObject.ApplyModifiedProperties();
    }
}
