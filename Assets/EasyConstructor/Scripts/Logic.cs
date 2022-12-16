using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class Logic : MonoBehaviour
{
    public List<LifeCyclesEventHandler> LifeCyclesHandlers;
    public List<MouseEventHandler> MouseHandlers;
    public List<KeyboardEventHandler> KeyboardHandlers;
    public List<CollisionEventHandlers> CollisionHandlers;
    public List<TriggerEventHandlers> TriggerHandlers;
 
  
    public void AddEventHandler(EventHandler eventHandler)
    {

        // Create Event lists
        if (LifeCyclesHandlers == null) LifeCyclesHandlers = new List<LifeCyclesEventHandler>();
        if (MouseHandlers == null) MouseHandlers = new List<MouseEventHandler>();
        if (KeyboardHandlers == null) KeyboardHandlers = new List<KeyboardEventHandler>();
        if (CollisionHandlers == null) CollisionHandlers = new List<CollisionEventHandlers>();
        if (TriggerHandlers == null) TriggerHandlers = new List<TriggerEventHandlers>();


        // Add event
        if (eventHandler.GetType() == typeof(LifeCyclesEventHandler)) LifeCyclesHandlers.Add(eventHandler as LifeCyclesEventHandler);
        if (eventHandler.GetType() == typeof(MouseEventHandler)) MouseHandlers.Add(eventHandler as MouseEventHandler);
        if (eventHandler.GetType() == typeof(KeyboardEventHandler)) KeyboardHandlers.Add(eventHandler as KeyboardEventHandler);
        if (eventHandler.GetType() == typeof(CollisionEventHandlers)) CollisionHandlers.Add(eventHandler as CollisionEventHandlers);
        if (eventHandler.GetType() == typeof(TriggerEventHandlers)) TriggerHandlers.Add(eventHandler as TriggerEventHandlers);
    }

    public void RemoveEventHandler(int index)
    {
        //KeyboardEventHandlers.RemoveAt(index);

       // EventHandlers.Remove(action);
    }

    public void ClearEventHandlers()
    {
      //  EventHandlers.Clear();
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
