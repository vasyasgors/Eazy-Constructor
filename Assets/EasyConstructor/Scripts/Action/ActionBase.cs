using System;
using System.Reflection;
using UnityEngine;

public enum ActionOwner
{
    Self,
    Other,
    Specified
}

public abstract class ActionBase : MonoBehaviour
{
    [SerializeField] private Condition condition;
    [SerializeField] private ActionOwner owner;

    [HideInInspector] public bool HideProperties;

    public Condition Condition { get { return condition; } }
    public ActionOwner Owner { get { return owner; } }

    public virtual void StartExecute() { }

    public virtual string GetHideString() { return name; }

   

    






 
    public new GameObject gameObject;


    protected Logic logic;

 

    public bool TryExecute(GameObject self, GameObject other)
    {

       if(owner == ActionOwner.Other)
            gameObject = other;

        if (owner == ActionOwner.Self)
            gameObject = self;


        logic = gameObject.GetComponent<Logic>();

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
        FieldInfo[] fieldInfo = GetType().GetFields();

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

