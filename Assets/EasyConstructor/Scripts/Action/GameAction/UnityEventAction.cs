using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ActionPath("UnityEventAction")]
public class UnityEventAction : ActionBase
{

    [SerializeField] private UnityEvent _event;

    public override void StartExecute()
    {
        
    }
}
