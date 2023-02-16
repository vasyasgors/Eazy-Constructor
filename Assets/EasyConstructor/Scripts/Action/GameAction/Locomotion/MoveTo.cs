using UnityEngine;


[ActionPath("Locomotion/MoveTo")]
public class MoveTo : ActionBase
{
    [SerializeField] private Transform target;
    [SerializeField] private FloatPicker speed;
    [SerializeField] private bool Smoothly = true;
    [SerializeField] private Space space;

    public override void StartExecute()
    {

        if (Smoothly == true)
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.position, speed.Value * Time.deltaTime);
        else
            gameObject.transform.position = target.position;
    }
}


