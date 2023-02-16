using UnityEngine;


[ActionPath("Locomotion/LookAt")]
public class LookAt: ActionBase
{
    [SerializeField] private Transform target;

    public override void StartExecute()
    {
        gameObject.transform.LookAt(target);
    }
}


