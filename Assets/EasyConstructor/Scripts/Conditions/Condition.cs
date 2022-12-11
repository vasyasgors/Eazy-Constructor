using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

// Возможно выделить в отдельные методы 
[System.Serializable]
public enum ConditionType
{
	Undefined,
	Equals,
	NotEqual,
	GreaterThan,
	SmallerThan,
	SmallerOrEqual,
	GreaterOrEqual
}

// НУЖНО ПРЯМ ОТТЕСТИРОВАТЬ 

[System.Serializable]
public class Condition  
{
	[SerializeField]
	private Object firstObject;
	[SerializeField]
	private string firstVariableName;

	[SerializeField]
	private Object secondObject;
	[SerializeField]
	private string secondVariableName;

	[SerializeField]
	private string operation;

	public bool Execute()
    {

		ConditionOperand firstOperand = new ConditionOperand(firstObject, firstVariableName);
		ConditionOperand secondOperand = new ConditionOperand(secondObject, secondVariableName);
		ConditionType condition = StringToType(operation);

		if (firstOperand.IsNumericType() == true)
        {
			// Переделать на джинерик метод
			double firstNumber = double.Parse( firstOperand.GetOperandValue().ToString() ) ;
			double secondNumber = double.Parse( secondOperand.GetOperandValue().ToString() );

			if (condition == ConditionType.Equals) return firstNumber == secondNumber;
			if (condition == ConditionType.NotEqual)  return firstNumber != secondNumber;
			if (condition == ConditionType.GreaterThan)  return firstNumber > secondNumber;
			if (condition == ConditionType.SmallerThan)  return firstNumber < secondNumber;
			if (condition == ConditionType.SmallerOrEqual)  return firstNumber <= secondNumber;
			if (condition == ConditionType.GreaterOrEqual)  return firstNumber >= secondNumber;
		}

		// Возможно переделать 
		if (condition == ConditionType.Equals) return firstOperand.GetOperandValue() == secondOperand.GetOperandValue();
		if (condition == ConditionType.NotEqual) return firstOperand.GetOperandValue() != secondOperand.GetOperandValue();


		return false;
	}










	public static ConditionType StringToType(string condition)
	{
		if (condition == "==") return ConditionType.Equals;
		if (condition == "!=") return ConditionType.NotEqual;
		if (condition == ">") return ConditionType.GreaterThan;
		if (condition == "<") return ConditionType.SmallerThan;
        if (condition == ">=") return ConditionType.GreaterOrEqual;
        if (condition == "<=") return ConditionType.SmallerOrEqual;


		return ConditionType.Undefined;

	}

	public static string TypeToString(ConditionType condition)
    {
		if (condition == ConditionType.Undefined) return "";
		if (condition == ConditionType.Equals) return "==";
		if (condition == ConditionType.NotEqual) return "!=";
		if (condition == ConditionType.GreaterThan) return ">";
		if (condition == ConditionType.SmallerThan) return "<";
		if (condition == ConditionType.GreaterOrEqual) return ">=";
		if (condition == ConditionType.SmallerOrEqual) return "<=";

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

