using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[ActionPath("Variable/AddDeltaTime")]
public class AddDeltaTime : ActionBase
{ 
    [SerializeField] [VariablePickerFilter(VariableTypes.Number)] private VariablePicker variable;


    public override void StartExecute()
    {
        float t = (float)variable.Variable.Value;

        t += Time.deltaTime;

        variable.Variable.Value = t;
    }
        


}
