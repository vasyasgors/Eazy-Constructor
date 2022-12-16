using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Locomotion/MoveTo")]
public class MoveTo : ActionBase
{

    public Transform target;

    public override void StartExecute()
    {
        transform.root.position = target.position;
    }

}
