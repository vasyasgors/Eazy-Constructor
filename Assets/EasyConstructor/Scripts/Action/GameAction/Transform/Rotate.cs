using UnityEngine;


[ActionPath("Transform/Rotate")]
public class Rotate : ActionBase
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private FloatPicker speed;
    [SerializeField] private bool useDeltaTime;
    [SerializeField] private Space space;

    public override void StartExecute()
    {
        gameObject.transform.Rotate(direction * speed.Value * (useDeltaTime == true ? Time.deltaTime : 1), space);
    }
}


