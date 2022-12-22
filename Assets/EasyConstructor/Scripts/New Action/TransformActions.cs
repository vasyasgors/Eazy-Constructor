using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

[System.Serializable]
public class MethodArgumentObject
{
    public int Int;
    public float Float;
    public bool Bool;
    public Vector3 Vector3;


    public Type[] argumentType;

    public object[] GetArgumentArray()
    {

        object[] arguments = new object[argumentType.Length];

        for(int i = 0; i < argumentType.Length; i++)
        {
            arguments[i] = GetValue(argumentType[i]);
        }

        return arguments;
    }


    public object GetValue(Type type)
    {
        if (type == typeof(int)) return Int;
        if (type == typeof(float)) return Float;
        if (type == typeof(bool)) return Bool;
        if (type == typeof(Vector3)) return Vector3;
        return new object();
    }

    
}


public class ActionContainer : MonoBehaviour
{

}

public class TransformActions : ActionContainer
{
    /*
    [SerializeField] private Space space;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private bool useDeltaTime;

    public void Move()
    {
        transform.Translate(direction * speed * (useDeltaTime == true ? Time.deltaTime : 1));
    }
   
    public void MoveTo()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * (useDeltaTime == true ? Time.deltaTime : 1));
    }

    public void Rotate()
    {
        transform.Rotate(direction * speed * (useDeltaTime == true ? Time.deltaTime : 1));
    }
    *

    public void RotateTo(Vector3 rotation, float speed, bool useDeltaTime)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(rotation), speed * (useDeltaTime == true ? Time.deltaTime : 1));
    }

    public void LookAt(Transform target)
    {
        transform.LookAt(target);
    }

    public void SetParent(Transform target)
    {
        transform.SetParent(target);
    }

    public void DetachChildren(Transform target)
    {
        target.DetachChildren();
    }

    public void JumpTo(Transform target)
    {
        transform.position = target.position;
    }

  
}


    */