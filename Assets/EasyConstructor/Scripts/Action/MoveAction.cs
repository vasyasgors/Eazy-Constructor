using UnityEngine;





[ActionPath("MoveAction")]
public class MoveAction : ActionBase
{
    public Vector3 direction;
    public PFloat speed;
    public bool useDeltaTime;
    public Space space;

    public override void StartExecute()
    {
        gameObject.transform.Translate(direction * speed.GetValue() * (useDeltaTime == true ? Time.deltaTime : 1));
    }

    public override string GetShortDescription()
    {
        return "Direction: " + direction + ", Speed : " + speed.ToString();
    }
}


