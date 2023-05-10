using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ActionPath("Rigidbody2D/AddTorque")]
public class AddTorque2D : ActionBase
{
    [SerializeField] private FloatPicker force;
    [SerializeField] private ForceMode2D mode;

    public override void StartExecute()
    {
        gameObject.GetComponent<Rigidbody2D>().AddTorque(force.Value, mode);
    }
}


