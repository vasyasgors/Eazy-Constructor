using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Logic : MonoBehaviour
{
    public List<EventHandler> eventHandlers;

    public void AddEventHandler<T>() where T : EventHandler
    {
        if (eventHandlers == null) eventHandlers = new List<EventHandler>();

        //eventHandlers.Add(ScriptableObject.CreateInstance<T>());
        eventHandlers.Add(  gameObject.AddComponent(typeof(T) ) as EventHandler);
    }

    public void RemoveEventHandler(EventHandler action)
    {
        eventHandlers.Remove(action);
    }

}
