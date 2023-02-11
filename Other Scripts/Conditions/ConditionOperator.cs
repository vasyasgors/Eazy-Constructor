using System;
using UnityEngine;

[Serializable]
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

[SerializeField]
public class ConditionOperator
{
	[SerializeField]
	private ConditionType type;
	
	public ConditionType Type { get { return type; } }

	public ConditionOperator(string conditionString)
    {
		type = ConditionType.Undefined;

		if (conditionString == "==") type = ConditionType.Equals;
		if (conditionString == "!=") type = ConditionType.NotEqual;
		if (conditionString == ">") type = ConditionType.GreaterThan;
		if (conditionString == "<") type = ConditionType.SmallerThan;
		if (conditionString == ">=") type = ConditionType.GreaterOrEqual;
		if (conditionString == "<=") type =  ConditionType.SmallerOrEqual;
	}

    public override string ToString()
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

