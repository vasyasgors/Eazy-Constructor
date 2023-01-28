using UnityEngine;


[ActionPath("Transform/Rotate")]
public class Rotate : ActionBase
{
    [SerializeField] private Vector3Prop direction;
    [SerializeField] private FloatProp speed;
    [SerializeField] private bool useDeltaTime;
    [SerializeField] private Space space;

    public override void StartExecute()
    {
        gameObject.transform.Rotate(direction.Value * speed.Value * (useDeltaTime == true ? Time.deltaTime : 1), space);
    }
}


