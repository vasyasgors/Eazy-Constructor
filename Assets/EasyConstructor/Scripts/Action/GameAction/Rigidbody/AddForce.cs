using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("AddForce")]
[RequireComponent(typeof(Rigidbody))]
public class AddForce : ActionBase
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private FloatPicker force;
    [SerializeField] private ForceMode mode;
    [SerializeField] private Space space;

    public override void StartExecute()
    {
        Vector3 forceVector = direction * force.Value;

        if (space == Space.Self)
            forceVector = gameObject.transform.InverseTransformDirection(forceVector);

        gameObject.GetComponent<Rigidbody>().AddForce(forceVector, mode);
    }
}
