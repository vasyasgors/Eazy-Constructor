using System;
using System.Reflection;
using UnityEngine;

public abstract class ActionBase : MonoBehaviour
{
    [SerializeField]
    private Condition condition;

    [HideInInspector] public bool HideProperties;

    public Condition Condition { get { return condition; } }

    public virtual void StartExecute() 
    {
     
 
    }

    public virtual string GetHideString() { return name; }

   
    public new GameObject gameObject;
 
    public Logic logic;


    public bool TryExecute()
    {

        LinkProperty();

        if (condition.Execute() == true)
        {
          //  Debug.Log(GetType());

            StartExecute();
            return true;
        }

        return false;
    }

    public bool TryExecute(GameObject gameObject, Logic logic)
    {
        this.gameObject = gameObject;
        this.logic = logic;

        LinkProperty();

        if (condition.Execute() == true)
        {
            StartExecute();
            return true;
        }

        return false;
    }

    private void LinkProperty()
    {
        FieldInfo[] fieldInfo = this.GetType().GetFields();

        for(int i = 0; i < fieldInfo.Length; i++)
        {
            if( fieldInfo[i].FieldType.IsSubclassOf(typeof(PropertyBase)))
            {

                ((PropertyBase)fieldInfo[i].GetValue(this)).logic = logic;
                Debug.Log(fieldInfo[i].FieldType);
            }
        }
    }


#if UNITY_EDITOR
    private void OnValidate()
    {
        //   hideFlags = HideFlags.HideInInspector;
    }
#endif

}

