using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;

[CreateAssetMenu(menuName = "Number")]
public class NumberScripabelVariable : ScriptableVariable, ISerializationCallbackReceiver
{
	[SerializeField] private float value;

	public void OnAfterDeserialize()
	{
		Variable.Value = value;
	}

	public void OnBeforeSerialize() { }
}