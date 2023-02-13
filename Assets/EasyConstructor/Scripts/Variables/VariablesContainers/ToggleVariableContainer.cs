using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

[CreateAssetMenu(menuName = "Toogle")]
public class ToggleVariableContainer : VariableContainer, ISerializationCallbackReceiver
{
	[SerializeField] private bool value;



    public void OnAfterDeserialize()
	{
		Variable.boolValue = value;
	}

	public void OnBeforeSerialize() { }
}