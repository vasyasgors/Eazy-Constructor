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
    [SerializeField] private string format;

    public override void StartExecute()
    {
        float t = (float) target.Variable.Value;
        text.text = t.ToString(format);
    }

  


}
