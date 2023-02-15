using UnityEngine;


[ActionPath("Transform/TurnTo")]
public class TurnTo : ActionBase
{
    [SerializeField] private Vector3 target;

    public override void StartExecute()
    {
        gameObject.transform.rotation = Quaternion.Euler(target);
    }
}


