using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Debug/Log")]
public class Log : ActionBase
{
	[SerializeField] private string _string;

    public override void StartExecute()
    {
        Debug.Log(_string);
    }

}
