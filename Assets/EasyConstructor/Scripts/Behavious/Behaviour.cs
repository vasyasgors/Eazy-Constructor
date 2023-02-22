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

    
    // По хорошему виделить в отдельный класс
    [SerializeField] [HideInInspector] private bool hasContainsMouseObjectEvents;

    private Behaviour objectBelowCursor;


    void Start()
    {
        TriggerEvents(EventGroups.LifeTime, LifeTimeEventType.Start.ToString(), EventProperties.None, gameObject, gameObject);
    }

    void Update()
    {
        TriggerEvents(EventGroups.LifeTime, LifeTimeEventType.Update.ToString(), EventProperties.None, gameObject, gameObject);

        // Проверять не по всему, а только по заданному
        foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(key))
                TriggerEvents(EventGroups.Keyboard, KeyboardEventType.Pressed.ToString(), key.ToString(), gameObject, gameObject);

            if (Input.GetKeyDown(key))
                TriggerEvents(EventGroups.Keyboard, KeyboardEventType.Down.ToString(), key.ToString(), gameObject, gameObject);

            if (Input.GetKeyUp(key))
                TriggerEvents(EventGroups.Keyboard, KeyboardEventType.Up.ToString(), key.ToString(), gameObject, gameObject);

        }


        if (Input.GetMouseButtonDown(0)) TriggerEvents(EventGroups.Mouse, MouseEventType.Down.ToString(), MouseEventProperties.Left.ToString(), gameObject, gameObject);
        if (Input.GetMouseButtonUp(0)) TriggerEvents(EventGroups.Mouse, MouseEventType.Up.ToString(), MouseEventProperties.Left.ToString(), gameObject, gameObject);
        if (Input.GetMouseButton(0)) TriggerEvents(EventGroups.Mouse, MouseEventType.Pressed.ToString(), MouseEventProperties.Left.ToString(), gameObject, gameObject);

        if (Input.GetMouseButtonDown(1)) TriggerEvents(EventGroups.Mouse, MouseEventType.Down.ToString(), MouseEventProperties.Right.ToString(), gameObject, gameObject);
        if (Input.GetMouseButtonUp(1)) TriggerEvents(EventGroups.Mouse, MouseEventType.Up.ToString(), MouseEventProperties.Right.ToString(), gameObject, gameObject);
        if (Input.GetMouseButton(1)) TriggerEvents(EventGroups.Mouse, MouseEventType.Pressed.ToString(), MouseEventProperties.Right.ToString(), gameObject, gameObject);

        if (Input.GetMouseButtonDown(2)) TriggerEvents(EventGroups.Mouse, MouseEventType.Down.ToString(), MouseEventProperties.Middle.ToString(), gameObject, gameObject);
        if (Input.GetMouseButtonUp(2)) TriggerEvents(EventGroups.Mouse, MouseEventType.Up.ToString(), MouseEventProperties.Middle.ToString(), gameObject, gameObject);
        if (Input.GetMouseButton(2)) TriggerEvents(EventGroups.Mouse, MouseEventType.Pressed.ToString(), MouseEventProperties.Middle.ToString(), gameObject, gameObject);


        // Упроситить логику или вообще убрать
        InvokeMouseObjectEvents();
    }

    private void InvokeMouseObjectEvents()
    {
        if (hasContainsMouseObjectEvents == true)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue) == true)
            {

                GameObject rootObject = hit.collider.transform.root.gameObject;
                Behaviour rootBehaviour = rootObject.GetComponent<Behaviour>();

                if (rootBehaviour != null)
                {
                    if (rootBehaviour != this) return;

                    if (objectBelowCursor == null)
                    {
                        objectBelowCursor = rootBehaviour;
                        TriggerEvents(EventGroups.Mouse, MouseEventType.ObjectEnter.ToString(), EventProperties.None, gameObject, gameObject);
                    }



                    if (Input.GetMouseButtonDown(0) == true)
                    {
                        TriggerEvents(EventGroups.Mouse, MouseEventType.ObjectDown.ToString(), EventProperties.None, gameObject, gameObject);
                    }

                }
            }
            else
            {
                if (objectBelowCursor != null)
                {
                    TriggerEvents(EventGroups.Mouse, MouseEventType.ObjectExit.ToString(), EventProperties.None, gameObject, gameObject);
                }

                objectBelowCursor = null;
            }
        }
    }

    void OnDestroy()
    {
        TriggerEvents(EventGroups.LifeTime, LifeTimeEventType.OnDestroy.ToString(), EventProperties.None, gameObject, gameObject);
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
        TriggerEvents(EventGroups.Collision, ColliderEventType.Enter.ToString(), other.transform.tag, gameObject, other.gameObject);
    }

    void OnCollisionExit(Collision other)
    {
        TriggerEvents(EventGroups.Collision, ColliderEventType.Exit.ToString(), other.transform.tag, gameObject, other.gameObject);
    }

    void OnCollisionStay(Collision other)
    {
        TriggerEvents(EventGroups.Collision, ColliderEventType.Stay.ToString(), other.transform.tag, gameObject, other.gameObject);
    }


    private void TriggerEvents(EventGroups group, string type, string properties, GameObject self, GameObject other)
    {
        if (enabled == false) return;

        for (int i = 0; i < EventHandlers.Count; i++)
        {
            EventHandlers[i].Invoke(group, type, properties, self, other);
        }
    }








    void UpdateHasContainsMouseObjectEvent()
    {
        hasContainsMouseObjectEvents = false;
        for (int i = 0; i < EventHandlers.Count; i++)
        {
            if (EventHandlers[i].Type == MouseEventType.ObjectDown.ToString() ||
                EventHandlers[i].Type == MouseEventType.ObjectEnter.ToString() ||
                EventHandlers[i].Type == MouseEventType.ObjectExit.ToString())
                hasContainsMouseObjectEvents = true;
        }
    }





    public Variable GetVariable(string name)
    {
        if(variables.Count == 0)
            throw new InvalidOperationException("Список переменных пуст!");

        for (int i = 0; i < variables.Count; i++)
        {
            if (variables[i].name == name)
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
            allNames[i] = variables[i].name;
        }
        return allNames;
    }

    public Variable[] GetAllVariables()
    {
        if (variables == null) return null;

        return variables.ToArray();
    }

    public void AddVariables(VariableTypes type)
    {
        if (variables == null) variables = new List<Variable>();

       variables.Add(new Variable(type));
    }





    public void AddEventHandler(EventHandler eventHandler)
    {
        if (EventHandlers == null) EventHandlers = new List<EventHandler>();

        EventHandlers.Add(eventHandler);

        UpdateHasContainsMouseObjectEvent();
    }

    public void RemoveEventHandler(int index)
    {

        EventHandlers[index].RemoveAllAction();
        EventHandlers.RemoveAt(index);


        UpdateHasContainsMouseObjectEvent();
       // EventHandlers.Remove(action);
    }

    public void ClearEventHandlers()
    {
        for(int i = 0; i < EventHandlers.Count; i++)
        {
            EventHandlers[i].RemoveAllAction();
        }

        UpdateHasContainsMouseObjectEvent();

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

                UpdateHasContainsMouseObjectEvent();
                return true;
            }
          
        }

        UpdateHasContainsMouseObjectEvent();
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
