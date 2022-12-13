using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class ActionContainer 
{

    public List<ActionBase> actions;


    public void Invoke()
    {
        
        for(int i = 0; i < actions.Count; i++)
        {
            
            actions[i].TryExecute();
        }
    }

    public void AddAction<T>(GameObject gameObject) where T : ActionBase
    {
        
        if (actions == null) actions = new List<ActionBase>();

      
        T action = gameObject.AddComponent(typeof(T)) as T;

     
        action.hideFlags = HideFlags.HideInInspector;

         actions.Add( action );         
        // actions.Add( ScriptableObject.CreateInstance<T>() );         
    }

    public void RemoveAction(ActionBase action)
    {

        GameObject.DestroyImmediate(action, true);
        actions.Remove(action);
    }

    public void ToogleActiveCondition(ActionBase action)
    {
        action.condition.ToggleActive();
    }


 

}

