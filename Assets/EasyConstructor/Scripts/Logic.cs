using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class Logic : MonoBehaviour
{

 //   public EventHandler ha;
    public List<EventHandler> EventHandlers;
 

    void Start()
    {

       
        for (int i = 0; i < EventHandlers.Count; i++)
        {


         


        }
    }
 
    void OnGUI()
    {
       

        Event e = Event.current;

        if (e != null)
        {

            if (e.isKey)
            {

               // Debug.Log(e.keyCode + " " + e.type.ToString());

                for (int i = 0; i < EventHandlers.Count; i++)
                {

                    MethodInfo methodInfo = EventHandlers[i].GetType().GetMethod("SyaMeow");

                  //  methodInfo.Invoke(EventHandlers[i], new object[] { e.keyCode, e.type });
                    methodInfo.Invoke(EventHandlers[i], null);



                }
            }
        }
    }


    public void AddEventHandler<T>(T eventHandler) where T : EventHandler
    {
        if (EventHandlers == null) EventHandlers = new List<EventHandler>();


        eventHandler.Type = eventHandler.GetType().ToString();

       // Debug.Log(eventHandler.GetType());

        EventHandlers.Add( eventHandler as T);

        

      
    }

    public void RemoveEventHandler(EventHandler action)
    {
        EventHandlers.Remove(action);
    }

    public void ClearEventHandlers()
    {
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
