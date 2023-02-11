using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("AddForce")]
public class AddForce : ActionBase
{
    [SerializeField] private Vector3Prop direction;
    [SerializeField] private FloatProp force;
    [SerializeField] private ForceMode mode;
    [SerializeField] private Space space;

    public override void StartExecute()
    {
        Vector3 forceVector = direction.Value * force.Value;

        if (space == Space.Self)
            forceVector = gameObject.transform.InverseTransformDirection(forceVector);

        gameObject.GetComponent<Rigidbody>().AddForce(forceVector, mode);
    }
}
