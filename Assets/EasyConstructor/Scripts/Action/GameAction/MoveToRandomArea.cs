using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Locomotion/MoveToRandomArea")]
public class MoveToRandomArea : ActionBase
{

	public Transform target;
	public Vector3 areaSize;

    public override void StartExecute()
    {
        transform.root.position = target.position + new Vector3(
            Random.Range(-areaSize.x * 0.5f, areaSize.x * 0.5f), 
            Random.Range(-areaSize.y * 0.5f, areaSize.y * 0.5f), 
            Random.Range(-areaSize.z * 0.5f, areaSize.z * 0.5f));
    }

    void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(target.position, areaSize);
        }
    }
}
