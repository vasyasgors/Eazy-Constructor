using UnityEngine;
using System;

/*
[Serializable]
public class ActionWrapper : SerializableClassWrapper
{
    [SerializeField] private Condition condition;
    [SerializeField] [HideInInspector] private string actionName;

    public ActionWrapper(ActionBase value, GameObject gameObject, Logic logic) : base(value)
    {
        actionName = value.GetType().ToString();
    }

    public ActionBase Action
    {
        get
        {
            return Value as ActionBase;
        }
    }

    public bool TryExecuteAction(GameObject gameObject, Logic logic)
    {

        if (condition.Execute() == true)
        {
            Action.gameObject = gameObject;
            Action.logic = logic;
            ((ActionBase)Value).gameObject = gameObject;

 

            Action.StartExecute();
            return true;
        }

        return false;
    }
}
*/

/*
[Serializable]
public class ActionWrapper  
{
   

    // Action in string
    [SerializeField] private string serializationString;
    [SerializeField] private string actionType;

    [NonSerialized] private ActionBase action;

    public ActionWrapper(ActionBase action, GameObject gameObject, Logic logic)
    {
        action.gameObject = gameObject;
        action.logic = logic;
        serializationString = SerializeAction(action);
        actionType = action.GetType().ToString();

    }

    public bool TryExecuteAction()
    {

        if (condition.Execute() == true)
        {
            Action.StartExecute();
            return true;
        }

        return false;
    }

    public ActionBase Action
    {
        get
        {
            if (action == null)
                return DeserializeAction(serializationString, actionType);
            else
                return action;
        }
       
    }

    public static ActionBase DeserializeAction(string serialized, string type)
    {
        return JsonUtility.FromJson(serialized, Type.GetType(type)) as ActionBase;
    }

    public static string SerializeAction(ActionBase action)
    {
        return JsonUtility.ToJson(action);
    }
}


    */
