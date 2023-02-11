using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ActionPath("Destroy")]
public class Destroy : ActionBase 
{
    [SerializeField] private FloatProp delay;

    public override void StartExecute()
    {
        Destroy(gameObject, delay.Value);
    }
}
