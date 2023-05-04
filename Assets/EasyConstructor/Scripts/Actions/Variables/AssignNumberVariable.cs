using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[ActionPath("Variable/AssignNumberVariable")]
public class AssignNumberVariable : ActionBase
{

    private static string[] Operation = new string[5] { "+=", "-=", "*=", "/=", "%=" };

    [SerializeField] [VariablePickerFilter(VariableTypes.Number)] private VariablePicker variable;

    [SerializeField] private string value;

    public override void StartExecute()
    { 
        if (value == "") return;

        if (value.Contains(Operation[0]) == true) variable.Variable.Value = (float)(variable.Variable.Value) + float.Parse(value.Substring(2));
        else if (value.Contains(Operation[1]) == true) variable.Variable.Value = (float)(variable.Variable.Value) - float.Parse(value.Substring(2));
        else if(value.Contains(Operation[2]) == true) variable.Variable.Value = (float)(variable.Variable.Value) * float.Parse(value.Substring(2));
        else if(value.Contains(Operation[3]) == true) variable.Variable.Value = (float)(variable.Variable.Value) / float.Parse(value.Substring(2));
        else if(value.Contains(Operation[4]) == true) variable.Variable.Value =  ( (float)(variable.Variable.Value) % (int) (float.Parse(value.Substring(2))));
        else variable.Variable.Value = float.Parse(value);
    }
        


}
