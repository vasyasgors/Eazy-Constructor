using UnityEngine;



public class DestoryAction : ActionBase
{
    public GameObject GameObject;
    public float Delay;
   // public bool destorySelf;

    public override void StartExecute()
    {

        Destroy(GameObject, Delay);
    }

}






