using UnityEngine;


[ActionPath("Transform/Move")]
public class Move : ActionBase
{
    [SerializeField] private Vector3Prop direction;
    [SerializeField] private FloatProp speed;
    [SerializeField] private bool useDeltaTime;
    [SerializeField] private Space space;

    public override void StartExecute()
    {
        gameObject.transform.Translate(direction.Value * speed.Value * (useDeltaTime == true ? Time.deltaTime : 1), space);
    }
}


