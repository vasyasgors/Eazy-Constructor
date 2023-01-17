using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class Logic : MonoBehaviour
{
    public List<EventHandler> EventHandlers;

    void Start()
    {
        TriggerEvents(EventGroups.LifeTime, LifeTimeEventType.Create.ToString(), EventProperties.None);
    }

    void Update()
    {
        TriggerEvents(EventGroups.LifeTime, LifeTimeEventType.Update.ToString(), EventProperties.None);
    }

    void OnDestory()
    {
        TriggerEvents(EventGroups.LifeTime, LifeTimeEventType.Destroy.ToString(), EventProperties.None);
    }


    void OnTriggerEnter(Collider other)
    {
        TriggerEvents(EventGroups.Trigger, ColliderEventType.Enter.ToString(), other.tag);
    }

    void OnTriggerExit(Collider other)
    {
        TriggerEvents(EventGroups.Trigger, ColliderEventType.Exit.ToString(), other.tag);
    }

    void OnTriggerStay(Collider other)
    {
        TriggerEvents(EventGroups.Trigger, ColliderEventType.Stay.ToString(), other.tag);
    }


    void OnCollisionEnter(Collision other)
    {
        TriggerEvents(EventGroups.Collision, ColliderEventType.Enter.ToString(), EventProperties.None);
    }

    void OnCollisionExit(Collision other)
    {
        TriggerEvents(EventGroups.Collision, ColliderEventType.Exit.ToString(), EventProperties.None);
    }

    void OnCollisionStay(Collision other)
    {
        TriggerEvents(EventGroups.Collision, ColliderEventType.Stay.ToString(), EventProperties.None);
    }






    private void TriggerEvents(EventGroups group, string type, string properties)
    {
        for (int i = 0; i < EventHandlers.Count; i++)
        {
            EventHandlers[i].Invoke(group, type, properties);
        }
    }



















    public void AddEventHandler(EventHandler eventHandler)
    {
        if (EventHandlers == null) EventHandlers = new List<EventHandler>();

        EventHandlers.Add(eventHandler);
    }

    public void RemoveEventHandler(int index)
    {

        EventHandlers[index].RemoveAllAction();
        EventHandlers.RemoveAt(index);
  
       // EventHandlers.Remove(action);
    }

    public void ClearEventHandlers()
    {
        for(int i = 0; i < EventHandlers.Count; i++)
        {
            EventHandlers[i].RemoveAllAction();
        }

        EventHandlers.Clear();
    }

    /*
    public enum EventType
    {
        Start,
        Update,
        OnTriggerEnter,
        OnKey,
        OnMoseDown
    }

    public EventType type;
    public KeyCode keyCode;
    public int  MouseButtonNumber;
    public string activateTag;
    public EventHandler container;


    void Awake()
    {
       // container.AssignGameObjectToAll(gameObject);
    }
    
    void Update()
    {
        if(type == EventType.Update)
        {
            container.Invoke();
        }

        if(Input.GetKey(keyCode) == true)
        {
            if (type == EventType.OnKey)
            {
                container.Invoke();
            }
           
        }

        if(Input.GetMouseButtonDown(MouseButtonNumber) == true)
        {
            if (type == EventType.OnMoseDown)
            {
                container.Invoke();
            }

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (type == EventType.OnTriggerEnter)
        {

           
            if (col.tag == activateTag || col.transform.root.tag == activateTag)
                container.Invoke();
        }
    }


    void Start()
    {
        if (type == EventType.Start)
        {
           
            container.Invoke();
        }
    }


    */


    /*
    public List<ActionContainer> eventHandlers;

    public void AddEventHandler<T>() where T : ActionContainer
    {
        if (eventHandlers == null) eventHandlers = new List<ActionContainer>();

        //eventHandlers.Add(ScriptableObject.CreateInstance<T>());
        eventHandlers.Add(  gameObject.AddComponent(typeof(T) ) as ActionContainer);
    }

    public void RemoveEventHandler(ActionContainer action)
    {
        eventHandlers.Remove(action);
    }
    */
}
