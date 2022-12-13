using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

// Создается очень много экземпляров 
//[CreateAssetMenu]
public class ActionBase : MonoBehaviour
{

    public Condition condition;

   
    void OnValidate()
    {
        hideFlags = HideFlags.HideInInspector;
    }

    public virtual void StartExecute()
    {

    }

    public bool TryExecute()
    {
        if(condition.Execute() == true)
        {
            StartExecute();
            return true;
        }

        return false;

    }



}






