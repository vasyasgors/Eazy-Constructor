using UnityEngine;
using System;


[ActionPath("Instance/Destory Instance")]
public class DestoryAction : ActionBase
{
    public GameObject GameObject;
    public float Delay;
   // public bool destorySelf;

    public override void StartExecute()
    {
        

        Destroy(gameObject, Delay);
    }

}






