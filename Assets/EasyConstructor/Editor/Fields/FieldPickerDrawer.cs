using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

using FieldPikerState = FieldPicker.FieldPikerState;

// Добавить авто изменение имени если переименовали локальную или ГЛОБАЛЬНУЮ переменную
[CustomPropertyDrawer(typeof(FieldPicker), true)]
public class FieldPickerDrawer : PropertyDrawer
{
    private const string StatePropertyFieldName = "state";
    private const string VariablePickerNameFieldName = "variablePicker";
    private const string ValueFieldName = "value";

    private const float WidthChangeModeButton = 40.0f;

    private SerializedProperty stateProperty;
    private SerializedProperty variablePickerProperty;
    private SerializedProperty valueProperty;

    //private Behaviour targetBehaviour;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        
        //targetBehaviour = (property.serializedObject.targetObject as MonoBehaviour).gameObject.GetComponent<Behaviour>();

        stateProperty = property.FindPropertyRelative(StatePropertyFieldName);
        variablePickerProperty = property.FindPropertyRelative(VariablePickerNameFieldName);
        valueProperty = property.FindPropertyRelative(ValueFieldName);

        FieldPikerState mode = (FieldPikerState) stateProperty.enumValueIndex;


        // Set filter

        variablePickerProperty.FindPropertyRelative("filter").enumValueIndex = (int) Variable.GetVariableType(valueProperty.type);
   
        position.width -= WidthChangeModeButton;

        if (mode == FieldPikerState.Value)
        {
            EditorGUI.PropertyField(position, valueProperty, label);
        }

        // Если label равно ноне, то фикачать на всю область 
       
        if (mode == FieldPikerState.Variable)
        {
            if (label == GUIContent.none)
            {
                EditorGUI.PropertyField(position, variablePickerProperty);
            }
            else
            {
                float labelWidth = position.width * 0.45f;
                float nameLable = position.width * 0.55f;

                position.width = labelWidth;

                EditorGUI.LabelField(position, label);

                position.x += labelWidth;
                position.width = nameLable;


                EditorGUI.PropertyField(position, variablePickerProperty);

            }
        
        }



        // Draw change mode button
        position.x += position.width;
        position.width = WidthChangeModeButton;

        if (GUI.Button(position, "V"))
        {

            if (mode == FieldPikerState.Value)
                stateProperty.enumValueIndex = (int) FieldPikerState.Variable;

            if (mode == FieldPikerState.Variable)
                stateProperty.enumValueIndex = (int) FieldPikerState.Value;
        }




        variablePickerProperty.serializedObject.ApplyModifiedProperties();
    }




}
