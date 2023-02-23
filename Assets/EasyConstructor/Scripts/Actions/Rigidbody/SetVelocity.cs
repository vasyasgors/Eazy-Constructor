using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ActionPath("Rigidbody/SetVelocity")]
public class SetVelocity : ActionBase
{
    [SerializeField] private Vector3 velocity;

    public override void StartExecute()
    {
        gameObject.GetComponent<Rigidbody>().velocity = velocity;
    }
}
