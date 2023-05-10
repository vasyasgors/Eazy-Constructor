using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ActionPath("Rigidbody2D/SetVelocity")]
public class SetVelocity2D : ActionBase
{
    [SerializeField] private Vector2 velocity;

    public override void StartExecute()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
