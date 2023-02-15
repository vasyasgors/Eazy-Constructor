using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("SetActive")]
public class SetActive : ActionBase 
{
   
    [SerializeField] private BoolPicker active;

    public override void StartExecute()
    {
        gameObject.SetActive(active.Value);
    }
}
