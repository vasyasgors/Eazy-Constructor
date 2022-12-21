using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActionContainer : MonoBehaviour
{
    [SerializeField]
    private Condition condition;


    public Condition Condition { get { return condition; } }

    public delegate void Action();

  
    

    public virtual void StartExecute() 
    {
      

    }



    public bool TryExecute()
    {
        if (condition.Execute() == true)
        {
            StartExecute();
            return true;
        }

        return false;
    }

}


public class TransformActions : ActionContainer
{
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
