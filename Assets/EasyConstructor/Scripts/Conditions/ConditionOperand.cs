using System;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class ConditionOperand 
{
	private Object sourceObject;
	private string propertyName;

	public Object SourceObject { get { return sourceObject; } }
	public string PropertyName { get { return propertyName; } }

    public ConditionOperand(Object sourceObject, string propertyName)
    {
        this.sourceObject = sourceObject;
        this.propertyName = propertyName;
    }

	// Написать какой-то обобщенный метод получения типо и значения, не важно что это
    public object GetOperandValue()
	{
		if (sourceObject == null) return new object();

		PropertyInfo propInfo = sourceObject.GetType().GetProperty(propertyName);

		FieldInfo fieldInfo = sourceObject.GetType().GetField(propertyName);

		if (propInfo != null) return propInfo.GetValue(sourceObject, null);

		if (fieldInfo != null) return fieldInfo.GetValue(sourceObject);

		return null;
	}

	public Type GetOperandType()
	{
	
		if (sourceObject == null) return null;

		PropertyInfo propInfo = sourceObject.GetType().GetProperty(propertyName);

		FieldInfo fieldInfo = sourceObject.GetType().GetField(propertyName);

		if(propInfo != null) return propInfo.PropertyType;

		if (fieldInfo != null) return fieldInfo.FieldType;

		return null;
	}
		
	public bool IsNumericType()
	{
		/*
		if (sourceObject == null) return false;

		PropertyInfo propInfo = sourceObject.GetType().GetProperty(propertyName);

		FieldInfo fieldInfo = sourceObject.GetType().GetField(propertyName);

		if (propInfo == null) return false;

		Type type = null;

		if (propInfo != null) 
			type = propInfo.GetValue(sourceObject, null).GetType();

		if (propInfo != null)
			type = fieldInfo.GetValue(sourceObject).GetType();

		Debug.Log(type);
		*/

		Type type = GetOperandType();

		Debug.Log(type);

		if (type == null) return false;

		switch (Type.GetTypeCode(type) )
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

