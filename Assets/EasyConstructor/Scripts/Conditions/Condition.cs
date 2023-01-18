using System;
using UnityEngine;
using Object = UnityEngine.Object;


[Serializable]
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
	private string operationString;

	[SerializeField]
	private bool isActive;
	
	public void ToggleActive()
    {
		isActive = !isActive;
	}

	public bool Execute()
    {
		if (isActive == false) return true;

		ConditionOperand firstOperand = new ConditionOperand(firstObject, firstVariableName);
		ConditionOperand secondOperand = new ConditionOperand(secondObject, secondVariableName);
		ConditionOperator condition = new ConditionOperator(operationString);

		if (firstOperand.IsNumericType() == true)
        {
			// Переделать на джинерик метод
			double firstNumber = double.Parse( firstOperand.GetOperandValue().ToString() ) ;
			double secondNumber = double.Parse( secondOperand.GetOperandValue().ToString() );

			if (condition.Type == ConditionType.Equals) return firstNumber == secondNumber;
			if (condition.Type == ConditionType.NotEqual)  return firstNumber != secondNumber;
			if (condition.Type == ConditionType.GreaterThan)  return firstNumber > secondNumber;
			if (condition.Type == ConditionType.SmallerThan)  return firstNumber < secondNumber;
			if (condition.Type == ConditionType.SmallerOrEqual)  return firstNumber <= secondNumber;
			if (condition.Type == ConditionType.GreaterOrEqual)  return firstNumber >= secondNumber;
		}

		// Возможно переделать 
		if (condition.Type == ConditionType.Equals) return firstOperand.GetOperandValue() == secondOperand.GetOperandValue();
		if (condition.Type == ConditionType.NotEqual) return firstOperand.GetOperandValue() != secondOperand.GetOperandValue();


		return false;
	}

	public bool IsCorrect()
    {
		ConditionOperand firstOperand = new ConditionOperand(firstObject, firstVariableName);
		ConditionOperand secondOperand = new ConditionOperand(secondObject, secondVariableName);
		ConditionOperator condition = new ConditionOperator(operationString);

		Debug.Log(firstOperand.IsNumericType() + " " +  secondOperand.IsNumericType());

		if (firstOperand.IsNumericType() == true && secondOperand.IsNumericType() == true)
			return true;
		else
			if ((firstOperand.GetOperandType() == secondOperand.GetOperandType()) && (condition.Type == ConditionType.Equals || condition.Type == ConditionType.NotEqual))
				return true;
			else
				return false;
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

