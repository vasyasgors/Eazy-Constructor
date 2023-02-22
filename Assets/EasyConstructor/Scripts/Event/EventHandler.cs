﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;








[System.Serializable]
public sealed class EventHandler
{
    public const string DefaultName = "EventHandler";

    public List<ActionBase> actions;

    public string DispalyName = DefaultName;


    public EventGroups Groupe;
    public string Type;
    public string Properties;

    public bool ToRemove = false;

    public EventHandler()
    {

    }

    public EventHandler(string groupe, string type, string properties)
    {
        Groupe = (EventGroups)Enum.Parse(typeof(EventGroups), groupe);
        Type = type;
        Properties = properties;


        if (Groupe == EventGroups.LifeTime)
            DispalyName = Type;
        else if(properties != EventProperties.None)
            DispalyName = Groupe.ToString() + " " +  Type + "-" + Properties;
        else
            DispalyName = Groupe.ToString() + " " + Type;
    }


    public void Invoke(EventGroups groups, string type, string properties, GameObject self, GameObject other)
    {

       
        // Некая оптимизация
        if (actions == null) return;

        if (actions.Count == 0) return;

        if (Groupe != groups) return;

        if (Type != type) return;

        if (Properties != properties) return;





        for (int i = 0; i < actions.Count; i++)
        {
         
            actions[i].TryExecute(self, other);
        }
    }


    public void ForceInvoke(GameObject self, GameObject other)
    {
        if (actions == null) return;

        if (actions.Count == 0) return;


        for (int i = 0; i < actions.Count; i++)
        {

            actions[i].TryExecute(self, other);
        }

    }

    /*
    public void AddAction<T>(GameObject gameObject) where T : ActionBase
    {

        if (actions == null) actions = new List<ActionBase>();


        T action = gameObject.AddComponent(typeof(T)) as T;




        actions.Add(action);
        // actions.Add( ScriptableObject.CreateInstance<T>() );         
    }*/

    public void AddAction(Type type, GameObject gameObject, MonoBehaviour container)
    {
        if (actions == null) actions = new List<ActionBase>();


        // не уверен что нужно так
        ActionBase action = gameObject.AddComponent(type) as ActionBase;
        action.SetContainer(container);


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
        if (actions == null) return;

        for (int i = 0; i < actions.Count; i++)
        {
            GameObject.DestroyImmediate(actions[i], true);
            actions.Remove(actions[i]);
        }
    }

    public void ToogleActiveCondition(ActionBase action)
    {
        action.Condition.ToggleActive();
    }


    public bool TryRemoveAction()
    {
        if (actions == null) return false;


        actions.RemoveAll(item => item == null);

        for (int i = 0; i < actions.Count; i++)
        {
            if (actions[i].ToRemove == true)
            {
                RemoveAction(actions[i]);
                return true;
            }
        }

        return false;
    }

 





}
