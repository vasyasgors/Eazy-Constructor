using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ActionPath("Variable/DispalyVariable")]
public class DispalyVariable : ActionBase
{
    [SerializeField] private VariablePicker target;
    [SerializeField] private Text text;

    public override void StartExecute()
    {
        text.text = target.Variable.Value.ToString();
    }

  


}
