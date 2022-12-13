using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : ActionBase
{

    public Transform target;

    public override void StartExecute()
    {
        transform.root.position = target.position;
    }

}
