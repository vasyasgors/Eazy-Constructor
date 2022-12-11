using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtAction : ActionBase
{

	public Transform source;
	public Transform target;

	public void LookAt()
    {
		source.LookAt(target);
    }
}
