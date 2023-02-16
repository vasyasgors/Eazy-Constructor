using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Rigidbody/SetKinematic")]
[RequireComponent(typeof(Rigidbody))]
public class SetKinematic : ActionBase
{
    [SerializeField] private ToggleState state;

    public override void StartExecute()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = ToggleStateExtensions.ToBool(state, gameObject.GetComponent<Rigidbody>().isKinematic);
    }
}
