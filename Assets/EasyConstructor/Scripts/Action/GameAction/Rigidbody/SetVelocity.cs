using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ActionPath("Rigidbody/SetVelocity")]
[RequireComponent(typeof(Rigidbody))]
public class SetVelocity : ActionBase
{
    [SerializeField] private Vector3 velocity;

    public override void StartExecute()
    {
        gameObject.GetComponent<Rigidbody>().velocity = velocity;
    }
}
