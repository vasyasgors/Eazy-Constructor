using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[ActionPath("Variable/AssignStringVariable")]
public class AssignStringVariable : ActionBase
{
    private static string[] Operation = new string[1] { "+="};

    [SerializeField] [VariablePickerType(VariableTypes.String)] private VariablePicker variable;
    [SerializeField] private string value;

    public override void StartExecute()
    {

        if (value.Contains(Operation[0]) == true) variable.Variable.Value = (variable.Variable.Value).ToString() + value.Substring(2);
        else variable.Variable.Value = value;
    }


}
