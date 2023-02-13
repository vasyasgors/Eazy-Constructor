using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[ActionPath("Variable/AssignNumberVariable")]
public class AssignNumberVariable : ActionBase
{

    private static string[] Operation = new string[4] { "+=", "-=", "*=", "/=" };

    [SerializeField] [OnlyVariable] private FloatProp variable;
    [SerializeField] private string value;

    public override void StartExecute()
    { 
        if (value == "") return;

        if (value.Contains(Operation[0]) == true) variable.Value += float.Parse(value.Substring(2));
        else if (value.Contains(Operation[1]) == true) variable.Value -= float.Parse(value.Substring(2));
        else if(value.Contains(Operation[2]) == true) variable.Value *= float.Parse(value.Substring(2));
        else if(value.Contains(Operation[3]) == true) variable.Value /= float.Parse(value.Substring(2));
        else variable.Value = float.Parse(value);
    }


}
