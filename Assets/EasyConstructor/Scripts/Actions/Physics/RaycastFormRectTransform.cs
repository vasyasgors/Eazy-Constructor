using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ActionPath("Physics/RaycastFormRectTransform")]
public class RaycastFormRectTransform : ActionBase
{ 
    [SerializeField] private  RectTransform source;

    public override void StartExecute()
    {
        Ray ray = Camera.main.ScreenPointToRay(source.position);

        RaycastHit hit;


        if (Physics.Raycast(ray, out hit) == true)
        {
            gameObject.transform.position = hit.point;
            gameObject.transform.forward = hit.normal;
        }
        else
        {
            gameObject.transform.position = ray.origin +  ray.direction * 100000;
        }
    }
}
