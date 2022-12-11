using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformAction : ActionBase
{

	public Transform source;
	public Transform target;

	public void LookAt()
    {
		source.LookAt(target);
    }
}
