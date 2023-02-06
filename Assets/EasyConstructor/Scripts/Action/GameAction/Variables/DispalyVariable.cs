using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ActionPath("Variable /DispalyVariable")]
public class DispalyVariable : ActionBase
{

	[SerializeField] private Text text;
	[SerializeField] private string variableName;

    public override void StartExecute()
    {

        text.text = logic.GetVariable(variableName).GetValue<float>().ToString();
    }
}
