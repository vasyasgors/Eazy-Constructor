using System;
using UnityEngine;
using Object = UnityEngine.Object;


[Serializable]
public class Condition  
{

	[SerializeField] private VariablePicker firstVariablePicker;
	[SerializeField] private ConditionType type;

	[SerializeField] private FloatPicker floatPicker;
	[SerializeField] private BoolPicker boolPicker;


	[SerializeField] private bool isActive;
	
	public void ToggleActive()
    {
		isActive = !isActive;
	}

	public bool Execute()
    {
		if (isActive == false) return true;

		if(firstVariablePicker.Variable.type == VariableTypes.Number)
        {
			if (type == ConditionType.Equals) return (float) firstVariablePicker.Variable.Value == floatPicker.Value;
			if (type == ConditionType.NotEqual) return (float) firstVariablePicker.Variable.Value != floatPicker.Value;
			if (type == ConditionType.GreaterOrEqual) return (float) firstVariablePicker.Variable.Value >= floatPicker.Value;
			if (type == ConditionType.GreaterThan) return (float) firstVariablePicker.Variable.Value > floatPicker.Value;
			if (type == ConditionType.SmallerOrEqual) return (float) firstVariablePicker.Variable.Value <= floatPicker.Value;
			if (type == ConditionType.SmallerThan) return (float) firstVariablePicker.Variable.Value < floatPicker.Value;

		}

		if(firstVariablePicker.Variable.type == VariableTypes.Toggle)
        {
			if (type == ConditionType.Equals) return (bool) firstVariablePicker.Variable.Value == boolPicker.Value;
			if (type == ConditionType.NotEqual) return (bool) firstVariablePicker.Variable.Value != boolPicker.Value;
		}

		return false;
	}

	public bool IsCorrect()
    {
		return false;
	}



	public static ConditionType StringToConditionType(string conditionString)
	{
		if (conditionString == "==") return ConditionType.Equals;
		if (conditionString == "!=") return  ConditionType.NotEqual;
		if (conditionString == ">") return ConditionType.GreaterThan;
		if (conditionString == "<") return ConditionType.SmallerThan;
		if (conditionString == ">=") return ConditionType.GreaterOrEqual;
		if (conditionString == "<=") return ConditionType.SmallerOrEqual;

		return ConditionType.Undefined;
	}

	public static string ConditionTypeToString(ConditionType type)
	{
		if (type == ConditionType.Undefined) return "";
		if (type == ConditionType.Equals) return "==";
		if (type == ConditionType.NotEqual) return "!=";
		if (type == ConditionType.GreaterThan) return ">";
		if (type == ConditionType.SmallerThan) return "<";
		if (type == ConditionType.GreaterOrEqual) return ">=";
		if (type == ConditionType.SmallerOrEqual) return "<=";

		return "";
	}



}






















/*
	public List<Type> ShowerType = new List<Type>() {
		typeof(int), 
		typeof(float), 
		typeof(bool), 
		typeof(Vector2),
		typeof(Vector3),
		typeof(Transform),
		typeof(GameObject),
		typeof(Material)
	};


	

    public UnityEngine.Object Left;
	public UnityEngine.Object Right;
	public string Operation;

	public PropertyInfo leftProperty;
	public PropertyInfo rightProperty;



	public bool CheckToPossibleEquale()
    {
		return leftProperty.PropertyType == rightProperty.PropertyType;
	}
	*/

