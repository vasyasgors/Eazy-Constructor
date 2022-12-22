using UnityEngine;


[ActionPath("Tranform/Move")]
public class MoveAction : ActionBase
{
    [SerializeField] Space space; [SerializeField] Vector3 direction; [SerializeField] float speed; [SerializeField] bool useDeltaTime;
    public override void StartExecute()
    {
        transform.Translate(direction * speed * (useDeltaTime == true ? Time.deltaTime : 1), space);
    }
}

[ActionPath("Tranform/MoveTo")]
public class MoveToAction : ActionBase
{
    [SerializeField] Transform target; [SerializeField] float speed; [SerializeField] bool useDeltaTime;
    public override void StartExecute()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * (useDeltaTime == true ? Time.deltaTime : 1));
    }
}

[ActionPath("Tranform/JumpTo")]
public class JumpToAction : ActionBase
{
    [SerializeField] Transform target; 
    public override void StartExecute()
    {
        transform.position = target.position;
    }
}

[ActionPath("Tranform/JumpToRandomArea")]
public class JumpToRandomArea : ActionBase
{

    [SerializeField] Transform target; [SerializeField] Vector3 areaSize;
    public override void StartExecute()
    {
        transform.root.position = target.position + new Vector3(
            Random.Range(-areaSize.x * 0.5f, areaSize.x * 0.5f),
            Random.Range(-areaSize.y * 0.5f, areaSize.y * 0.5f),
            Random.Range(-areaSize.z * 0.5f, areaSize.z * 0.5f));
    }

    void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(target.position, areaSize);
        }
    }
}

[ActionPath("Tranform/Rotate")]
public class RotateAction : ActionBase
{
    [SerializeField] Vector3 direction;[SerializeField] float speed;[SerializeField] bool useDeltaTime;
    public override void StartExecute()
    {
        transform.Rotate(direction * speed * (useDeltaTime == true ? Time.deltaTime : 1));
    }
}

[ActionPath("Tranform/RotateTo")]
public class RotateToAction : ActionBase
{
    [SerializeField] Vector3 rotation; [SerializeField] float speed;[SerializeField] bool useDeltaTime;
    public override void StartExecute()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(rotation), speed * (useDeltaTime == true ? Time.deltaTime : 1));
    }
}


[ActionPath("Tranform/LookAt")]
public class LookAtAction : ActionBase
{
    [SerializeField] Transform target;
    public override void StartExecute()
    {
        transform.LookAt(target);
    }
}


[ActionPath("Tranform/SetParent")]
public class SetParentAction : ActionBase
{
    [SerializeField] Transform target;
    public override void StartExecute()
    {
        transform.SetParent(target);
    }
}

[ActionPath("Tranform/DetachChildren")]
public class DetachChildAction : ActionBase
{
    [SerializeField] Transform target;
    public override void StartExecute()
    {
        target.DetachChildren();
    }
}

