using UnityEngine;

[ActionPath("Transform/DetachChildren")]
public class DetachChildren : ActionBase
{
    public override void StartExecute()
    {
        gameObject.transform.DetachChildren();
    }
}


