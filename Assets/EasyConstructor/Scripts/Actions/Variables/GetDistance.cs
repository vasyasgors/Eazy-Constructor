using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[ActionPath("Variable/GetDistance")]
public class GetDistance : ActionBase
{
    [SerializeField] private TransformPicker from;
    [SerializeField] private TransformPicker to;
    [SerializeField] [VariablePickerFilter(VariableTypes.Number)] private VariablePicker resultVariable;


    public override void StartExecute()
    {
        resultVariable.Variable.Value = Vector3.Distance(from.Value.position, to.Value.position);
    }

}
