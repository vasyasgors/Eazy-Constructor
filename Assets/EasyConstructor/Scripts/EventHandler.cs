using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventHandler : MonoBehaviour
{
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
    public ActionContainer container;


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
