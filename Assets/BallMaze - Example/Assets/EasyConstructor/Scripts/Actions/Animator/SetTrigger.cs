using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Amimator/SetTrigger")]

public class SetTrigger : ActionBase 
{
    [SerializeField] private string triggerName;

    public override void StartExecute()
    {
        gameObject.GetComponent<Animator>().SetTrigger(triggerName);

    }
}
