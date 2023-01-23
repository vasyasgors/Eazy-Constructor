using UnityEngine;
using System;

[Serializable]
public class ActionWrapper  
{
    [SerializeField] private Condition condition;

    // Action in string
    [SerializeField] private string serializationString;
    [SerializeField] private string actionType;

    [NonSerialized] private ActionBase action;

    public ActionWrapper(ActionBase action, GameObject gameObject)
    {
        action.gameObject = gameObject;
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


