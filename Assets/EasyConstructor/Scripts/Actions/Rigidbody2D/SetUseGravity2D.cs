using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ActionPath("Rigidbody2D/SetUseGravity2D")]
public class SetUseGravity2D : ActionBase
{
    [SerializeField] private FloatPicker gravityScale;

    public override void StartExecute()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityScale.Value;
    }
}
