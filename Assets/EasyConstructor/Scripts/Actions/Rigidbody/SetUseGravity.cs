using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ActionPath("Rigidbody/SetUseGravity")]
[RequireComponent(typeof(Rigidbody))]
public class SetUseGravity : ActionBase
{
    [SerializeField] private ToggleState state;

    public override void StartExecute()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = ToggleStateExtensions.ToBool(state, gameObject.GetComponent<Rigidbody>().useGravity);
    }
}
