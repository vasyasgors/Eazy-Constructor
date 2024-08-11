using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;

[CreateAssetMenu(menuName = "Variables/Toggle")]
public class ToggleVariable : ScriptableVariable, ISerializationCallbackReceiver
{
	[SerializeField] private bool value;

	public void OnAfterDeserialize()
	{
		Variable.Value = value;
	}

	public void OnBeforeSerialize() { }
}