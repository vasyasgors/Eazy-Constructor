using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ActionPath("ShowVariableText")]
public class ShowVariableText : ActionBase
{

    [SerializeField] private string variableName;
    [SerializeField] private Text text;

    public override void StartExecute()
    {

        text.text = logic.GetVariable(variableName).floatValue.ToString();

    }
}

