using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

// Добавить авто изменение имени если переименовали локальную или ГЛОБАЛЬНУЮ переменную
[CustomPropertyDrawer(typeof(PropertyBase), true)]
public class PropertyEditorDrawer : PropertyDrawer
{
    private const string ModePropertyFieldName = "mode";
    private const string VariableNameFieldName = "variableName";
    private const string GlobalVariableReferenceFieldName = "globalVariable";
    private const string valueFieldName = "value";

    private const float WidthChangeModeButton = 40.0f;

    private SerializedProperty drawModeProperty;
    private SerializedProperty variableNameProperty;
    private SerializedProperty valueProperty;
    private SerializedProperty globalVariableProperty;

    private Behaviour targetBehaviour;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        targetBehaviour = (property.serializedObject.targetObject as MonoBehaviour).gameObject.GetComponent<Behaviour>();

        drawModeProperty = property.FindPropertyRelative(ModePropertyFieldName);
        variableNameProperty = property.FindPropertyRelative(VariableNameFieldName);
        valueProperty = property.FindPropertyRelative(valueFieldName);
        globalVariableProperty = property.FindPropertyRelative(GlobalVariableReferenceFieldName);

        PropertyMode mode = (PropertyMode)drawModeProperty.enumValueIndex;

        bool isOnlyVariable = IsOnlyVariable();

        // Draw Property

        // Сброс мода
        if (isOnlyVariable == true && drawModeProperty.enumValueIndex == (int)PropertyMode.Value)
            drawModeProperty.enumValueIndex = (int)PropertyMode.Variable;

        if (isOnlyVariable == false)
            position.width -= WidthChangeModeButton;

        if (mode == PropertyMode.Value)
        {
            EditorGUI.PropertyField(position, valueProperty, label);
        }

        if (mode == PropertyMode.Variable || mode == PropertyMode.GlobalVariable)
        {
            float labelWidth = position.width * 0.45f;
            float nameLable = position.width * 0.55f;

            position.width = labelWidth;

            EditorGUI.LabelField(position, label);

            position.x += labelWidth;
            position.width = nameLable;

            /*
            string[] allVariablesName = GetGlobalVariables();

            if (allVariablesName.Length == 0)
            {
                EditorGUI.DropdownButton(position, new GUIContent("List of variables is empty!"), FocusType.Passive);
            }
            else*/
            {
                if (EditorGUI.DropdownButton(position, new GUIContent(variableNameProperty.stringValue), FocusType.Passive))
                {
                    BuildVariableMenu(property).DropDown(position);
                }
            }
        }


        if (isOnlyVariable == false)
        {
            // Draw change mode button
            position.x += position.width;
            position.width = WidthChangeModeButton;

            if (GUI.Button(position, "V"))
            {

                if (mode == PropertyMode.Value)
                    drawModeProperty.enumValueIndex = (int)PropertyMode.Variable;

                if (mode == PropertyMode.Variable || mode == PropertyMode.GlobalVariable)
                    drawModeProperty.enumValueIndex = (int)PropertyMode.Value;
            }
        }

        variableNameProperty.serializedObject.ApplyModifiedProperties();

    }

    private bool IsOnlyVariable()
    {
        object[] attributes = fieldInfo.GetCustomAttributes(false);

        for (int i = 0; i < attributes.Length; i++)
        {
            if (attributes[i] is OnlyVariableAttribute)
            {
                return true;
              
            }
        }

        return false;
    }

    private void AssigneVariableName(object var)
    {

        if(var is Variable)
        {
            variableNameProperty.stringValue = (var as Variable).Name.ToString();

            variableNameProperty.serializedObject.ApplyModifiedProperties();

            drawModeProperty.enumValueIndex = (int)PropertyMode.Variable;
            drawModeProperty.serializedObject.ApplyModifiedProperties();
        }

        if (var is GlobalVariable)
        {

            variableNameProperty.stringValue = (var as GlobalVariable).name.ToString();
            variableNameProperty.serializedObject.ApplyModifiedProperties();

            globalVariableProperty.objectReferenceValue = (var as GlobalVariable);
            globalVariableProperty.serializedObject.ApplyModifiedProperties();


            drawModeProperty.enumValueIndex = (int)PropertyMode.GlobalVariable;
            drawModeProperty.serializedObject.ApplyModifiedProperties();

        }






        /*
        variableNameProperty.stringValue = varName.ToString();
        variableNameProperty.serializedObject.ApplyModifiedProperties();
        */
    }

    private GenericMenu BuildVariableMenu(SerializedProperty property)
    {
        GenericMenu menu = new GenericMenu();




        // Local
        Variable[] localVariables = GetLocalVariables(IsOnlyVariable());


        for(int i = 0; i < localVariables.Length; i++)
        {
            menu.AddItem(new GUIContent(localVariables[i].Name), false, AssigneVariableName, localVariables[i]);
        }


        // Global
        GlobalVariable[] globalVariables = GetGlobalVariables(IsOnlyVariable());

        for (int i = 0; i < globalVariables.Length; i++)
        {
            menu.AddItem(new GUIContent(globalVariables[i].name), false, AssigneVariableName, globalVariables[i]);
        }


        return menu;
    }





    // Переписать в общую логику с параметром 
    private Variable[] GetLocalVariables(bool anyType)
    {
        Variable[] localVariables = targetBehaviour.GetAllVariables();
        List<Variable> variables = new List<Variable>();

        if (localVariables == null) return null;

        for (int i = 0; i < localVariables.Length; i++)
        {
            if (anyType == false && localVariables[i].CompareType(valueProperty.type) == true)
            {
                variables.Add(localVariables[i]);
            }
            
            else if(anyType == true)
            {
                variables.Add(localVariables[i]);
            }
        }

        return variables.ToArray();
    }

    private GlobalVariable[] GetGlobalVariables(bool anyType)
    {
        GlobalVariable[] globalVariables = GlobalVariable.GetAllInstances<GlobalVariable>();
        List<GlobalVariable> variables = new List<GlobalVariable>();


        if (globalVariables == null) return null;

        if (globalVariables != null && globalVariables.Length > 0)
        {
            for (int i = 0; i < globalVariables.Length; i++)
            {
                if (anyType == false && globalVariables[i].Variable.CompareType(valueProperty.type) == true)
                {
                    variables.Add(globalVariables[i]);
                }

                else if (anyType == true)
                {
                    variables.Add(globalVariables[i]);
                }

            }
        }

        return variables.ToArray();
    }



}
