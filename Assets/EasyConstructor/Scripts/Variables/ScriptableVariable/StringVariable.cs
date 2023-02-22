using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;

[CreateAssetMenu(menuName = "Variables/String")]
public class StringVariable : ScriptableVariable, ISerializationCallbackReceiver
{
	[SerializeField] private string value;

	public void OnAfterDeserialize()
	{
		Variable.Value = value;
	}

	public void OnBeforeSerialize() { }
}