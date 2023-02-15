using UnityEngine;


[ActionPath("Transform/MoveTo")]
public class MoveToTransform : ActionBase
{
    [SerializeField] private Transform target;
    [SerializeField] private FloatPicker speed;
    [SerializeField] private bool useDeltaTime;
    [SerializeField] private Space space;

    public override void StartExecute()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.position, speed.Value * (useDeltaTime == true ? Time.deltaTime : 1));
    }
}


