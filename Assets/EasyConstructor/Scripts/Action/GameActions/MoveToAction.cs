using UnityEngine;

[ActionPath("Tranform/MoveTo")]
public class MoveToAction : ActionBase
{
    [SerializeField] Transform target; [SerializeField] float speed; [SerializeField] bool useDeltaTime;
    public override void StartExecute()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * (useDeltaTime == true ? Time.deltaTime : 1));
    }
}

