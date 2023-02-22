using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

// Добавить авто изменение имени если переименовали локальную или ГЛОБАЛЬНУЮ переменную
[CustomPropertyDrawer(typeof(VariablePicker), true)]
public class VariablePikerDrawer : PropertyDrawer
{
    private const string VariableNameFieldName = "variableName";
    private const string OwnerFieldName = "owner";
    private const string FilterFieldName = "filter";

    private SerializedProperty variableNameProperty;
    private SerializedProperty ownerProperty;
    private SerializedProperty FilterProperty;

    private Behaviour targetBehaviour;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        targetBehaviour = (property.serializedObject.targetObject as MonoBehaviour).gameObject.GetComponent<Behaviour>();

        variableNameProperty = property.FindPropertyRelative(VariableNameFieldName);
        ownerProperty = property.FindPropertyRelative(OwnerFieldName);
        FilterProperty = property.FindPropertyRelative(FilterFieldName);
        
        if (EditorGUI.DropdownButton(position, new GUIContent(variableNameProperty.stringValue), FocusType.Passive))
        {
            BuildVariableMenu(property).DropDown(position);
        }
            
        variableNameProperty.serializedObject.ApplyModifiedProperties();
    }



    private void AssigneVariableName(object var)
    {

        if(var is Variable)
        {
            variableNameProperty.stringValue = (var as Variable).name;
            variableNameProperty.serializedObject.ApplyModifiedProperties();

        
            ownerProperty.objectReferenceValue = targetBehaviour;
            ownerProperty.serializedObject.ApplyModifiedProperties();
        }

        if(var is ScriptableVariable)
        {
            variableNameProperty.stringValue = (var as ScriptableVariable).name;
            variableNameProperty.serializedObject.ApplyModifiedProperties();


            ownerProperty.objectReferenceValue = (var as ScriptableVariable);
            ownerProperty.serializedObject.ApplyModifiedProperties();
        }


    }

    private GenericMenu BuildVariableMenu(SerializedProperty property)
    {
        GenericMenu menu = new GenericMenu();

        // Local
        Variable[] localVariables = GetLocalVariables();

        if (localVariables != null)
        {
            for (int i = 0; i < localVariables.Length; i++)
            {
                menu.AddItem(new GUIContent(localVariables[i].name), false, AssigneVariableName, localVariables[i]);
            }
        }

        // Global
        ScriptableVariable[] globalVariable = GetScriptabelVariable();

        if (globalVariable != null)
        {
            for (int i = 0; i < globalVariable.Length; i++)
            {
                menu.AddItem(new GUIContent(globalVariable[i].name), false, AssigneVariableName, globalVariable[i]);
            }
        }

        return menu;
    }


    private bool HasRestrictType(ref VariableTypes type)
    {
        object[] attributes = fieldInfo.GetCustomAttributes(false);

        for (int i = 0; i < attributes.Length; i++)
        {
            if (attributes[i] is VariablePickerTypeAttribute)
            {
                type = (attributes[i] as VariablePickerTypeAttribute).Type;
                return true;

            }
        }

        return false;
    }



    // Переписать в общую логику с параметром 
    private Variable[] GetLocalVariables()
    {
        if (targetBehaviour == null) return null;

        List<Variable> localVariables = targetBehaviour.GetAllVariables().ToList();
        List<Variable> variables = new List<Variable>();

        if (localVariables == null) return null;

        VariableTypes restrictType = VariableTypes.Any;

        bool hasRestrictType = HasRestrictType(ref restrictType);

        if(FilterProperty.enumValueIndex != (int)VariableTypes.Any)
        {
            restrictType = (VariableTypes)FilterProperty.enumValueIndex;
            hasRestrictType = true;
        }


        for (int i = 0; i < localVariables.Count; i++)
        {
            if ( hasRestrictType == true && localVariables[i].type == restrictType )
            {
                variables.Add(localVariables[i]);
            }
            else if(hasRestrictType == false)
            {
                variables.Add(localVariables[i]);
            }
        }

        return variables.ToArray();
    }

    private ScriptableVariable[] GetScriptabelVariable()
    {
        List<ScriptableVariable> scriptabelVariable = ScriptableVariable.GetAllInstances().ToList();

        List<ScriptableVariable> variables = new List<ScriptableVariable>();

        if (scriptabelVariable == null) return null;

        VariableTypes restrictType = VariableTypes.Any;

        bool hasRestrictType = HasRestrictType(ref restrictType);

        if (FilterProperty.enumValueIndex != (int)VariableTypes.Any)
        {
            restrictType = (VariableTypes)FilterProperty.enumValueIndex;
            hasRestrictType = true;
        }


        for (int i = 0; i < scriptabelVariable.Count; i++)
        {
            if (hasRestrictType == true && scriptabelVariable[i].Variable.type == restrictType)
            {
                variables.Add(scriptabelVariable[i]);
            }
            else if (hasRestrictType == false)
            {
                variables.Add(scriptabelVariable[i]);
            }
        }

        return variables.ToArray();
    }








}
