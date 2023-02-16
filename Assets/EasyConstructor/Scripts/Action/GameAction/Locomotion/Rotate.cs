using UnityEngine;


[ActionPath("Locomotion/Rotate")]
public class Rotate : ActionBase
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private FloatPicker speed;
    [SerializeField] private Space space;

    public override void StartExecute()
    {
        gameObject.transform.Rotate(direction * speed.Value * Time.deltaTime, space);
    }
}


