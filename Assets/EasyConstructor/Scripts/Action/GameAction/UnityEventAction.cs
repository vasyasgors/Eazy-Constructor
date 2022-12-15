using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventAction : ActionBase
{
    public UnityEvent Event;

    public override void StartExecute()
    {
        if (Event != null)
            Event.Invoke();
    }
}
