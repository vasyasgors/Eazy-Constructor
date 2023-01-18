using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Variable /ChangeFloatVariable")]
public class SetFloatVariable : ActionBase
{
    [SerializeField] private FloatVariable variable;
    [SerializeField] private string value;
    [SerializeField] private bool relative;

    public override void StartExecute()
    {
        if (relative == false)
            variable.Value = float.Parse(value);

        if (relative == true)
        {
            variable.Value += float.Parse(value);
        }

    }
}
