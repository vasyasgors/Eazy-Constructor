using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[ActionPath("Variable/AssignToggleVariable")]
public class AssignToggleVariable : ActionBase
{

    [SerializeField] [OnlyVariable] private BoolProp variable;
    [SerializeField] private ToggleState state;

    public override void StartExecute()
    {
        variable.Value = state.ToBool(variable.Value);
    }


}
