using UnityEngine;


[ActionPath("Locomotion/Move")]
public class Move : ActionBase
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private FloatPicker speed;
    [SerializeField] private Space space;

    public override void StartExecute()
    {
        gameObject.transform.Translate(direction * speed.Value * Time.deltaTime, space);
    }
}


