using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCommand : CommandBase
{

	public Transform source;
	public Transform target;

	public void LookAt()
    {
		source.LookAt(target);
    }
}
