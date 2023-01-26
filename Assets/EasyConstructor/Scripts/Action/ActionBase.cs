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
    public int FirstADctionsdf;
    public int gasf;
    public int FirstAasdfaDctionsdf;
    public int FirstAsdfasdfaDctionsdf;
    public int FirsgsdsfasdfafdasdtADctionsdf;
    public int FirsfasdftADctionsdf;
    public int FirstADfasdascdfastionsdf;
    public int FirstADcfasdfationsdf;
    public int FirstADdfasdctionsdf;

  //  public PInt test;

    public override void StartExecute()
    {
      
        
        //Debug.Log("FirstAction " + test.Value + " " + FirstADctionsdf);

      //  GameObject.Destroy(gameObject);
    }
}




