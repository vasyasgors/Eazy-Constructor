using UnityEngine;

[ActionPath("Tranform/Move")]
[AddComponentMenu("MoveAction")]
public class MoveAction : ActionBase
{
    [SerializeField] private Space space;[SerializeField] private Vector3 direction;[SerializeField] private float speed;[SerializeField] private bool useDeltaTime;
    public override void StartExecute()
    {
        transform.Translate(direction * speed * (useDeltaTime == true ? Time.deltaTime : 1), space);
    }
}


