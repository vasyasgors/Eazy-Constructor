using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ActionPath("Destroy")]
public class Destroy : ActionBase 
{
    [SerializeField] private FloatPicker delay;

    public override void StartExecute()
    {
        Destroy(gameObject, delay.Value);
    }
}
