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

        if (meshRenderer.material == first.Value)
        {
            meshRenderer.material = second.Value;
            return;
        }

        if (meshRenderer.material == second.Value)
        {
            meshRenderer.material = first.Value;
            return;
        }

        meshRenderer.material = first.Value;






    }
}
