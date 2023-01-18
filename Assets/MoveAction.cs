using UnityEngine;

[ActionPath("Tranform/Move")]

public class MoveAction : ActionBase
{
    [SerializeField] private Space space; 
    [SerializeField] private PVector3 direction; 
    [SerializeField] private PFloat speed; 
    [SerializeField] private PBool useDeltaTime;

    public override void StartExecute()
    {
        transform.Translate(direction.Value * speed.Value * (useDeltaTime.Value == true ? Time.deltaTime : 1), space);
    }

}


