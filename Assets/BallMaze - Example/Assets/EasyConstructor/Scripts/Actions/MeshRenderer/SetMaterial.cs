using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("MeshRenderer/SetMaterial")]
public class SetMaterial : ActionBase 
{
    [SerializeField] private MaterialPicker material;

    public override void StartExecute()
    {
        gameObject.GetComponent<MeshRenderer>().material = material.Value;   
    }
}
