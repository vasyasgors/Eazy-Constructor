using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public  class EventHandler : SerializeCustomClass
{
    public List<ActionBase> actions;

    public string DispalyName = "EventHandler";

    public void SyaMeow()
    {
        Debug.Log("Meow");
    }



    protected virtual void Invoke()
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

    public void AddAction(Type type, GameObject gameObject)
    {
        if (actions == null) actions = new List<ActionBase>();


        // не уверен что нужно так
        ActionBase action = gameObject.AddComponent(type) as ActionBase;


        action.hideFlags = HideFlags.HideInInspector;

        actions.Add(action);
    }



    public void RemoveAction(ActionBase action)
    {

        GameObject.DestroyImmediate(action, true);
        actions.Remove(action);
    }

    public void ToogleActiveCondition(ActionBase action)
    {
        action.Condition.ToggleActive();
    }


 

}

