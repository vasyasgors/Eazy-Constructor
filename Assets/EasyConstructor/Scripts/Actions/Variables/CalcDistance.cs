using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[ActionPath("Variable/CalcDistance")]
public class CalcDistance : ActionBase
{
    [SerializeField] private TransformPicker from;
    [SerializeField] private TransformPicker to;
    [SerializeField] [VariablePickerType(VariableTypes.Number)] private VariablePicker resultVariable;


    public override void StartExecute()
    {
        resultVariable.Variable.Value = Vector3.Distance(from.Value.position, to.Value.position);
    }
        


}
