using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Instances/FindObjectWithTag")]
public class FindObjectWithTag : ActionBase
{
    [SerializeField] [VariablePickerType(VariableTypes.Transform)] private VariablePicker variable;
	[SerializeField] private string _tag;

    public override void StartExecute()
    {
        variable.Variable.Value = (object) GameObject.FindGameObjectWithTag(_tag).transform;
    }
}
