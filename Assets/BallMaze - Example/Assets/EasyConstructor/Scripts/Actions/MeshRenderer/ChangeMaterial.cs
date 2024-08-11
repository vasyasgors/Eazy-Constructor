using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("MeshRenderer/ChangeMaterial")]
public class ChangeMaterial : ActionBase 
{
    [SerializeField] private MaterialPicker first;
    [SerializeField] private MaterialPicker second;

    private MeshRenderer meshRenderer;

    public override void StartExecute()
    {
        if (meshRenderer == null)
        {
            meshRenderer = gameObject.GetComponent<MeshRenderer>();

            if (meshRenderer == null) return;
        }

        if (meshRenderer.sharedMaterial == first.Value)
        {
            meshRenderer.sharedMaterial = second.Value;
         
            return;
        }

        if (meshRenderer.sharedMaterial == second.Value)
        {
            meshRenderer.sharedMaterial = first.Value;
            return;
        }

    






    }
}
