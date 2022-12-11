using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;


public class EventHandler : MonoBehaviour
{

    public List<ActionBase> actions;


    public void Invoke()
    {
        for(int i = 0; i < actions.Count; i++)
        {
            
            actions[i].TryExecute();
        }
    }

    public void AddAction<T>() where T : ActionBase
    {
        if (actions == null) actions = new List<ActionBase>();

        actions.Add( ScriptableObject.CreateInstance<T>() );
        //actions.Add(gameObject.AddComponent(typeof(T)) as ActionBase);
        
    }

    public void RemoveAction(ActionBase action)
    {
        DestroyImmediate(action, true);
        actions.Remove(action);
    }

    public void ToogleActiveCondition(ActionBase action)
    {
        action.condition.ToggleActive();
    }

}

