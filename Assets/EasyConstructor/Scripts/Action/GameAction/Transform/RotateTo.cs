using UnityEngine;


[ActionPath("Transform/RotateTo")]
public class RotateTo : ActionBase
{
    [SerializeField] private Vector3 targetRotation;
    [SerializeField] private FloatPicker speed;
    [SerializeField] private bool useDeltaTime;
    [SerializeField] private Space space;

    public override void StartExecute()
    {
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.Euler(targetRotation), speed.Value * (useDeltaTime == true ? Time.deltaTime : 1));
    }
}


