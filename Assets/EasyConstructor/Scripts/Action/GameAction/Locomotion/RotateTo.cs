using UnityEngine;


[ActionPath("Locomotion/RotateTo")]
public class RotateTo : ActionBase
{
    [SerializeField] private Vector3 targetRotation;
    [SerializeField] private FloatPicker speed;
    [SerializeField] private bool Smoothly = true;
    [SerializeField] private Space space;

    public override void StartExecute()
    {
        if (Smoothly == true)
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.Euler(targetRotation),
                speed.Value * Time.deltaTime);
        else
            gameObject.transform.rotation = Quaternion.Euler(targetRotation);
    }
}


