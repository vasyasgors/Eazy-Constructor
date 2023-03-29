using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ActionPath("Physics/RaycastFormMouse")]
public class RaycastFormMouse : ActionBase
{
    public override void StartExecute()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y; 

        Vector3 mousePos = new Vector3(mouseX, mouseY, Camera.main.nearClipPlane);
        Vector3 position = Camera.main.ScreenToWorldPoint(mousePos);

        RaycastHit hit;
        if (Physics.Raycast(position, Camera.main.transform.forward, out hit) == true)
        {
            gameObject.transform.position = hit.point;
            gameObject.transform.forward = hit.normal;
        }
        else
        {
            gameObject.transform.position = position + Camera.main.transform.forward * 100000;
        }
    }
}
