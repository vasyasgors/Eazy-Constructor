using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Locomotion/SetScale")]
public class SetScale : ActionBase
{
    [SerializeField] private Vector3 scale;
    [SerializeField] private FloatPicker speed;
    [SerializeField] private bool Smoothly = true;

    public override void StartExecute()
    {

        if (Smoothly == true)
            gameObject.transform.localScale = Vector3.MoveTowards(gameObject.transform.position, scale, speed.Value * Time.deltaTime);
        else
            gameObject.transform.localScale = scale;
    }
}

