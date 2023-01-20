using UnityEngine;
using System;


[Serializable]
public class ActionWrapper  //: ISerializationCallbackReceiver
{
    [SerializeField]
    public string serialazableString;
   
    [System.NonSerialized]
    public ActionBase Action;


   

    public string type;

    public ActionBase GetAction()
    {
        if (Action == null)
            return DeserializeAction(serialazableString, type);
        else
            return Action;
    }


    public static ActionBase DeserializeAction(string serialized, string type)
    {

    

        return JsonUtility.FromJson(serialized, Type.GetType(type)) as ActionBase;
    }

    public static string SerializeAction(ActionBase action)
    {
        return JsonUtility.ToJson(action);
    }

    public void OnAfterDeserialize()
    {
         Action = JsonUtility.FromJson(serialazableString, Type.GetType(type)) as ActionBase; 
    }

    public void OnBeforeSerialize()
    { 
        serialazableString = JsonUtility.ToJson( Action );
    }

 
}

// Добавить задержку

public class ActionBase 
{
    //[SerializeField] private Condition condition;

  //  public Condition Condition { get { return condition; } }

   

    public virtual void StartExecute() { Debug.Log("MEOW"); }

    public bool TryExecute()
    {

       // if (condition.Execute() == true)
        {
            StartExecute();
            return true;
        }

        return false;
    }
}


[ActionPath("FirstAction")]

public class FirstAction : ActionBase
{

    public GameObject gameObject;

    public string name;


    public override void StartExecute()
    {
        Debug.Log("FirstAction " + gameObject + " " + name);

      //  GameObject.Destroy(gameObject);
    }
}


[ActionPath("SecondAction")]
public class SecondAction : ActionBase
{
  
    public Transform position;

    public float speed;
 

    public override void StartExecute()
    {
        Debug.Log("SecondAction " + position + " " + speed);
    }
}



/*

[Serializable]
public class Action : ActionBase
{
    public Action()
    {
        paramAm = 0;
    }
}

[Serializable]
public class Action<T1> : ActionBase
{
    public T1 parametr1;

    public Action()
    {
        paramAm = 1;
    }
}

[Serializable]
public class Action<T1, T2> : ActionBase
{
    public T1 parametr1;
    public T2 parametr2;

    public Action()
    {
        paramAm = 2;
    }
}

[Serializable]
public class Action<T1, T2, T3> : ActionBase
{
    public T1 parametr1;
    public T2 parametr2;
    public T3 parametr3;

    public Action()
    {
        paramAm = 3;
    }
}

[Serializable]
public class Action<T1, T2, T3, T4> : ActionBase
{
    public T1 parametr1;
    public T2 parametr2;
    public T3 parametr3;
    public T4 parametr4;

    public Action()
    {
        paramAm = 4;
    }
}

// Сделать аккуратнее
[AttributeUsage(AttributeTargets.Class)]
public class ActionParametrNames : Attribute
{
    public string[] Names;

    public ActionParametrNames(string name1)
    {
        Names = new string[1];
        Names[0] = name1;
    }

    public ActionParametrNames(string name1, string name2)
    {
        Names = new string[2];
        Names[0] = name1;
        Names[1] = name2;
    }

    public ActionParametrNames(string name1, string name2, string name3)
    {
        Names = new string[3];
        Names[0] = name1;
        Names[1] = name2;
        Names[3] = name3;
    }

    public ActionParametrNames(string name1, string name2, string name3, string name4)
    {
        Names = new string[4];
        Names[0] = name1;
        Names[1] = name2;
        Names[2] = name3;
        Names[3] = name4;
    }
}
*/







