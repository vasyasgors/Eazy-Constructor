using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("TestAction2")]
[AddComponentMenu("TestAction2")]
public class TestAction2 : ActionBase
{
    [SerializeField] private Space space;[SerializeField] private Vector3 direction;[SerializeField] private float speed;[SerializeField] private bool useDeltaTime;
    public override void StartExecute()
    {
        transform.Translate(direction * speed * (useDeltaTime == true ? Time.deltaTime : 1), space);
    }

}


[ActionPath("TestAction3")]
[AddComponentMenu("TestAction3")]
public class TestAction3 : ActionBase
{
    [SerializeField] private Space space;[SerializeField] private Vector3 direction;[SerializeField] private float speed;[SerializeField] private bool useDeltaTime;
    public override void StartExecute()
    {
        transform.Translate(direction * speed * (useDeltaTime == true ? Time.deltaTime : 1), space);
    }

}
