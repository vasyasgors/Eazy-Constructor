using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ActionPath("Mouse/FollowMouse")]
public class FollowMouse : ActionBase
{
    [SerializeField] private FloatPicker ZOffset;
    [SerializeField] private BoolPicker useXAxis;
    [SerializeField] private BoolPicker useYAxis;

    public override void StartExecute()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y; 

        Vector3 mousePos = new Vector3(mouseX, mouseY, Camera.main.nearClipPlane + ZOffset.Value);
        Vector3 position = Camera.main.ScreenToWorldPoint(mousePos);

        if (useXAxis.Value == false) position.x = gameObject.transform.position.x;
        if (useYAxis.Value == false) position.y = gameObject.transform.position.y;

        gameObject.transform.position = position;
    }
}
