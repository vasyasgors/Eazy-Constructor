using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : ActionBase {

    public Transform target;
    public Vector3 step;
    public bool UseDeltaTime;

    public override void StartExecute()
    {
        if (UseDeltaTime)
            target.Rotate(step * Time.deltaTime);
        else
            target.Rotate(step);
    }
}
