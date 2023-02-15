using UnityEngine;


[ActionPath("Transform/JumpToTransform")]
public class JumpToTransform : ActionBase
{
    [SerializeField] private Transform target;

    public override void StartExecute()
    {
        gameObject.transform.position = target.position;
    }
}


