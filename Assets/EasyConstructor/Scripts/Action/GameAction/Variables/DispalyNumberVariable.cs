using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ActionPath("Variable/DispalyNumberVariable")]
public class DispalyNumberVariable : ActionBase
{

    [SerializeField] private FloatPicker target;
    [SerializeField] private Text text;


    public override void StartExecute()
    {

        float t = 0;
/*
        if (target.mode == PikerMode.Variable)
            t = behaviour.GetVariable(target.variableName).floatValue;

        if (target.mode == PikerMode.GlobalVariable)
            t = target.globalVariable.Variable.floatValue;
*/

        text.text = t.ToString();
    }

  


}
