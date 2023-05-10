using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Rigidbody2D/SetKinematic")]
public class SetKinematic2D : ActionBase
{
    [SerializeField] private ToggleState state;

    public override void StartExecute()
    {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = ToggleStateExtensions.ToBool(state, gameObject.GetComponent<Rigidbody>().isKinematic);
    }
}
