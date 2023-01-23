using UnityEngine;

// Добавить задержку
// Добавить поторы
// string изначально null, возможно, нужно вызывать конструктор при создании объекта
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




