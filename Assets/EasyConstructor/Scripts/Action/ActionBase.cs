using UnityEngine;

// Добавить задержку
// Добавить поторы
// string изначально null, возможно, нужно вызывать конструктор при создании объекта
public class ActionBase : SerializableClass
{
    [HideInInspector]
    public GameObject gameObject;
    [HideInInspector]
    public Logic logic;

    public virtual void StartExecute() {}
}


[ActionPath("FirstAction")]
public class FirstAction : ActionBase
{
    public int FirstActionsdf;

    public PInt test;

    public override void StartExecute()
    {
      
        
        Debug.Log("FirstAction " + test.Value + " " + FirstActionsdf);

      //  GameObject.Destroy(gameObject);
    }
}




