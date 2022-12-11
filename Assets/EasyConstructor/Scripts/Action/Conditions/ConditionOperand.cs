using System;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

[System.Serializable]
public class ConditionOperand 
{
	public Object sourceObject;
	public string propertyName;

    public ConditionOperand(Object sourceObject, string propertyName)
    {
        this.sourceObject = sourceObject;
        this.propertyName = propertyName;
    }

    public object GetOperandValue()
	{
		if (sourceObject == null) return new object();

		return sourceObject.GetType().GetProperty(propertyName).GetValue(sourceObject, null);
	}

	public Type GetOperandType()
	{
		if (sourceObject == null) return null;

		return sourceObject.GetType().GetProperty(propertyName).GetType();
	}
		
	public bool IsNumericType()
	{
		if (sourceObject == null) return false; 

		switch (Type.GetTypeCode(  sourceObject.GetType().GetProperty(propertyName).GetValue(sourceObject, null).GetType())  )
		{
			case TypeCode.Byte:
			case TypeCode.SByte:
			case TypeCode.UInt16:
			case TypeCode.UInt32:
			case TypeCode.UInt64:
			case TypeCode.Int16:
			case TypeCode.Int32:
			case TypeCode.Int64:
			case TypeCode.Decimal:
			case TypeCode.Double:
			case TypeCode.Single:
				return true;
			default:
				return false;
		}
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

