using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ActionPath("Special/ActionContainer")]
public class ActionsContainer : ActionBase
{
    [SerializeField] public EventHandler actions;

    public override void StartExecute()
    {
        actions.ForceInvoke(gameObject, gameObject);
    }
}

