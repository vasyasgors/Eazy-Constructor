using UnityEngine;


[ActionPath("Transform/RotateTo")]
public class RotateTo : ActionBase
{
    [SerializeField] private Vector3Prop targetRotation;
    [SerializeField] private FloatProp speed;
    [SerializeField] private bool useDeltaTime;
    [SerializeField] private Space space;

    public override void StartExecute()
    {
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.Euler(targetRotation.Value), speed.Value * (useDeltaTime == true ? Time.deltaTime : 1));
    }
}


