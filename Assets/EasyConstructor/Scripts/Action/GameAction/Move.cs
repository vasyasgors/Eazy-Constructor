using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Locomotion/Move")]
public class Movea : ActionBase {

	//public Transform target;


	public Vector3 step;
    public bool UseDeltaTime;

    public override void StartExecute()
    {
        if (UseDeltaTime)
            gameObject.transform.root.Translate(step * Time.deltaTime);
        else
            gameObject.transform.root.Translate(step);
    }

}
