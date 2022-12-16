using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class Logic : MonoBehaviour
{

 //   public EventHandler ha;
    public List<EventHandler> lifeCyclesEventHandlers;
    public List<KeyboardEventHandler> KeyboardEventHandlers;
 

    void Start()
    {

       
     
    }
 
    void OnGUI()
    {
       

        Event e = Event.current;

        if (e != null)
        {

            if (e.isKey)
            {

               // Debug.Log(e.keyCode + " " + e.type.ToString());

                for (int i = 0; i < KeyboardEventHandlers.Count; i++)
                {


                    KeyboardEventHandlers[i].Invoke(e.keyCode, e.type);
                }
            }
        }
    }


    public void AddEventHandler(EventHandler eventHandler)
    { 
        if(eventHandler.GetType() == typeof(KeyboardEventHandler))
        {
            if (KeyboardEventHandlers == null) KeyboardEventHandlers = new List<KeyboardEventHandler>();

            KeyboardEventHandlers.Add(eventHandler as KeyboardEventHandler);
        }

      
      
    }

    public void RemoveEventHandler(EventHandler action)
    {
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
