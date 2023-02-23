using UnityEngine;


[ActionPath("Locomotion/LookAt")]
public class LookAt: ActionBase
{
    [SerializeField] private Transform target;

    [SerializeField] private FloatPicker speed;
    [SerializeField] private bool Smoothly = true;

    public override void StartExecute()
    {

        if (Smoothly == true)
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.LookRotation(target.position - gameObject.transform.position), Time.deltaTime * speed.Value);
        else
            gameObject.transform.LookAt(target);


    }
}


