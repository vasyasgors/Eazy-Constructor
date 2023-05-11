using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Rigidbody2D/AddForce2D")]
public class AddForce2D : ActionBase
{
    [SerializeField] private Vector2 direction;
    [SerializeField] private FloatPicker force;
    [SerializeField] private ForceMode2D mode;
    [SerializeField] private Space space;

    public override void StartExecute()
    {
        Vector3 forceVector = direction * force.Value;

        if (space == Space.Self)
            forceVector = gameObject.transform.InverseTransformDirection(forceVector);

        gameObject.GetComponent<Rigidbody2D>().AddForce(forceVector, mode);
    }
}
