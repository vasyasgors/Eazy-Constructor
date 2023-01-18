using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;








[System.Serializable]
public sealed class EventHandler
{
    public List<ActionBase> actions;

    public string DispalyName = "EventHandler";


    public EventGroups Groupe;
    public string Type;
    public string Properties;

    public EventHandler()
    {

    }

    public EventHandler(string groupe, string type, string properties)
    {
        Groupe = (EventGroups) Enum.Parse( typeof(EventGroups), groupe);
        Type = type;
        Properties = properties;


        if (Groupe == EventGroups.LifeTime)
            DispalyName = Type;
        else
            DispalyName = Groupe.ToString() + Type + "-" + Properties;
    }



 

    private void Invoke()
    {
        for (int i = 0; i < actions.Count; i++)
        {
            actions[i].TryExecute();
        }
    }

    public  void Invoke(EventGroups groups, string type, string properties)
    {

       // Debug.Log(groups+ " " + type + " " + properties);
        //Debug.Log(Groupe + " " + Type + " " + Properties);

        if (Groupe != groups) return;

        if (Type != type) return;
        
        if (Properties != properties) return;
        
        
        for(int i = 0; i < actions.Count; i++)
        {
            actions[i].TryExecute();
        }
    }

    public void AddAction<T>(GameObject gameObject) where T : ActionBase
    {
        
        if (actions == null) actions = new List<ActionBase>();

      
        T action = gameObject.AddComponent(typeof(T)) as T;

     
       

         actions.Add( action );         
        // actions.Add( ScriptableObject.CreateInstance<T>() );         
    }

    public void AddAction(Type type, GameObject gameObject)
    {
        if (actions == null) actions = new List<ActionBase>();


        // не уверен что нужно так
        ActionBase action = gameObject.AddComponent(type) as ActionBase;



        actions.Add(action);
    }

    public void ToggleHideAction(ActionBase action)
    {
        action.HideProperties = !action.HideProperties;
    }

    public bool GetHideAction(ActionBase action)
    {
        return action.HideProperties;
    }

    public void RemoveAction(ActionBase action)
    {
        
        GameObject.DestroyImmediate(action, true);
        actions.Remove(action);
    }

    public void RemoveAllAction()
    {
        for(int i = 0; i < actions.Count; i++)
        {
            GameObject.DestroyImmediate(actions[i], true);
            actions.Remove(actions[i]);
        }
    }

    public void ToogleActiveCondition(ActionBase action)
    {
        action.Condition.ToggleActive();
    }


 

}

