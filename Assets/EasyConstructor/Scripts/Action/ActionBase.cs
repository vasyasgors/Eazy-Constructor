using UnityEngine;

// Добавить задержку
public class ActionBase 
{

    public GameObject gameObject;

    public virtual void StartExecute() {}
}


[ActionPath("FirstAction")]
public class FirstAction : ActionBase
{
    public string FirstActionsdf;

    public override void StartExecute()
    {
        Debug.Log("FirstAction " + gameObject + " " + FirstActionsdf);

        GameObject.Destroy(gameObject);
    }
}


[ActionPath("SecondAction")]
public class SecondAction : ActionBase
{
    public PVector3 direction;
    public PFloat speed;
    public Space space;
 
    public override void StartExecute()
    {
        gameObject.transform.Translate(direction.Value * speed.Value * Time.deltaTime);
    }
}


