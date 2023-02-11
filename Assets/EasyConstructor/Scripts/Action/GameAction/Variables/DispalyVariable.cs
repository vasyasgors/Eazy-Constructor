using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ActionPath("Variable /DispalyVariable")]
public class DispalyVariable : ActionBase
{

    [SerializeField] private FloatProp target;
    [SerializeField] private Text text;


    public override void StartExecute()
    {

        float t = 0;

        if (target.mode == PropertyMode.Variable)
            t = behaviour.GetVariable(target.variableName).floatValue;

        if (target.mode == PropertyMode.GlobalVariable)
            t = target.globalVariable.Variable.floatValue;


        text.text = t.ToString();
    }

  


}
