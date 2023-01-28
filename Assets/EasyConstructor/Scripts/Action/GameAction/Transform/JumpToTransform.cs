using UnityEngine;


[ActionPath("Transform/JumpToTransform")]
public class JumpToTransform : ActionBase
{
    [SerializeField] private TransformProp target;

    public override void StartExecute()
    {
        gameObject.transform.position = target.Value.position;
    }
}


