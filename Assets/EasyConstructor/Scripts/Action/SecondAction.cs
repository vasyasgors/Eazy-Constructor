using UnityEngine;





[ActionPath("SecondAction")]
public class SecondAction : ActionBase
{

    public PFloat speed;

    public Space space;
    public override void StartExecute()
    {
        gameObject.transform.Translate(Vector3.up * speed.GetValue() * Time.deltaTime);
    }
}


