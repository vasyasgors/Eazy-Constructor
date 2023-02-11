using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;



// Добавить проверку на enabled
public class Behaviour : MonoBehaviour
{
    public List<Variable> variables;

    public List<EventHandler> EventHandlers;

    void Start()
    {
        TriggerEvents(EventGroups.LifeTime, LifeTimeEventType.Create.ToString(), EventProperties.None, gameObject, gameObject);
    }

    void Update()
    {
        TriggerEvents(EventGroups.LifeTime, LifeTimeEventType.Update.ToString(), EventProperties.None, gameObject, gameObject);

        // Проверять не по всему, а только по заданному
        foreach(KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(key))
                TriggerEvents(EventGroups.Keyboard, KeyboardEventType.Pressed.ToString(), key.ToString(), gameObject, gameObject);

            if (Input.GetKeyDown(key))
                TriggerEvents(EventGroups.Keyboard, KeyboardEventType.Down.ToString(), key.ToString(), gameObject, gameObject);

            if (Input.GetKeyUp(key))
                TriggerEvents(EventGroups.Keyboard, KeyboardEventType.Up.ToString(), key.ToString(), gameObject, gameObject);

        }
       
    }

    void OnDestory()
    {
        TriggerEvents(EventGroups.LifeTime, LifeTimeEventType.Destroy.ToString(), EventProperties.None, gameObject, gameObject);
    }


    void OnTriggerEnter(Collider other)
    {
        TriggerEvents(EventGroups.Trigger, ColliderEventType.Enter.ToString(), other.tag, gameObject, other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        TriggerEvents(EventGroups.Trigger, ColliderEventType.Exit.ToString(), other.tag, gameObject, other.gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        TriggerEvents(EventGroups.Trigger, ColliderEventType.Stay.ToString(), other.tag, gameObject, other.gameObject);
    }


    void OnCollisionEnter(Collision other)
    {
        TriggerEvents(EventGroups.Collision, ColliderEventType.Enter.ToString(), EventProperties.None, gameObject, other.gameObject);
    }

    void OnCollisionExit(Collision other)
    {
        TriggerEvents(EventGroups.Collision, ColliderEventType.Exit.ToString(), EventProperties.None, gameObject, other.gameObject);
    }

    void OnCollisionStay(Collision other)
    {
        TriggerEvents(EventGroups.Collision, ColliderEventType.Stay.ToString(), EventProperties.None, gameObject, other.gameObject);
    }

    void OnMouseDown()
    {
        TriggerEvents(EventGroups.Mouse, MouseEventType.ObjectDown.ToString(), EventProperties.GetMouseProperties()[0], gameObject, gameObject);
    }


    private void TriggerEvents(EventGroups group, string type, string properties, GameObject self, GameObject other)
    {
        if (enabled == false) return;

        for (int i = 0; i < EventHandlers.Count; i++)
        {
            EventHandlers[i].Invoke(group, type, properties, self, other);
        }
    }














    public Variable GetVariable(string name)
    {
        if(variables.Count == 0)
            throw new InvalidOperationException("Список переменных пуст!");

        for (int i = 0; i < variables.Count; i++)
        {
            if (variables[i].Name == name)
                return variables[i];
        }

        throw new InvalidOperationException("Переменная с именем" + name +  " не найдена!");
    }

    public string[] GetAllVariabelsName()
    {
        string[] allNames = new string[variables.Count];

        if(variables == null) return new string[0] {};

        if (variables.Count == 0) return new string[0];

        for (int i = 0; i < variables.Count; i++)
        {
            allNames[i] = variables[i].Name;
        }
        return allNames;
    }

    public Variable[] GetAllVariables()
    {
        if (variables == null) return null;

        return variables.ToArray();
    }

    public void AddVariables(VariableTypeNames type)
    {
        if (variables == null) variables = new List<Variable>();

       variables.Add(new Variable(type));
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


    public bool TryRemoveEventHandler()
    {
        if (EventHandlers == null) return false;

        for (int i = 0; i < EventHandlers.Count; i++)
        {
            if(EventHandlers[i].ToRemove == true)
            {

                EventHandlers[i].RemoveAllAction();
                EventHandlers.RemoveAt(i);
                return true;
            }
          
        }

        return false;
    }

    public bool TryRemoveVariables()
    {
        if (variables == null) return false;

        for (int i = 0; i < variables.Count; i++)
        {
            if (variables[i].ToRemove == true)
            {
                variables.RemoveAt(i);
                return true;
            }

        }

        return false;
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
