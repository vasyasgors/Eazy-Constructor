using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

[CreateAssetMenu(menuName = "Number")]
public class NumberVariableContainer : ScriptableVariable, ISerializationCallbackReceiver
{
	[SerializeField] private float value;



	public void OnAfterDeserialize()
	{
		//Variable.floatValue = value;
	}

	public void OnBeforeSerialize() { }
}