using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[ActionPath("Variable/AssignToggleVariable")]
public class AssignToggleVariable : ActionBase
{
    [SerializeField] [VariablePickerType(VariableTypes.Toggle)] private VariablePicker variable;
    [SerializeField] private ToggleState state;

    public override void StartExecute()
    {
        variable.Variable.Value =  state.ToBool((bool) variable.Variable.Value);
    }


}
