﻿using UnityEngine;


[ActionPath("Transform/LookAtTransform")]
public class LookAtTransform : ActionBase
{
    [SerializeField] private TransformProp target;

    public override void StartExecute()
    {
        gameObject.transform.LookAt(target.Value);
    }
}


