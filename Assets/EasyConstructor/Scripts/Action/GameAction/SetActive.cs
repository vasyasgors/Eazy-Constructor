using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("SetActive")]
public class SetActive : ActionBase 
{
    [SerializeField] private GameObjectProp target;
    [SerializeField] private BoolProp active;

    public override void StartExecute()
    {
        target.Value.SetActive(active.Value);
    }
}
