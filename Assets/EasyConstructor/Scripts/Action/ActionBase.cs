using System;
using System.Reflection;
using UnityEngine;

public enum ActionOwner
{
    Self,
    Other,
    Specific
}

public abstract class ActionBase : MonoBehaviour
{
    [SerializeField] private Condition condition;
    [SerializeField] private ActionOwner owner;



    [HideInInspector] public bool HideProperties;
    [HideInInspector] public float Delay;
    [HideInInspector] public int Loop = -1;
    [HideInInspector] public bool ToRemove = false;


    public Condition Condition { get { return condition; } }
    public ActionOwner Owner { get { return owner; } set { owner = value; } }

    public virtual void StartExecute() { }

    public virtual string GetShortDescription() { return name; }

   

    






 
    public new GameObject gameObject;


    protected Behaviour logic;

 

    public bool TryExecute(GameObject self, GameObject other)
    {

       if(owner == ActionOwner.Other)
            gameObject = other;

        if (owner == ActionOwner.Self)
            gameObject = self;


        logic = gameObject.GetComponent<Behaviour>();

        LinkProperty();

        if (condition.Execute() == true)
        {
            StartExecute();
            return true;
        }

        return false;
    }

    // Надо как-то оптмизировать это дело, вызывать 1 раз
    private void LinkProperty()
    {
        FieldInfo[] fieldInfo = GetType().GetFields();

        for(int i = 0; i < fieldInfo.Length; i++)
        {
            if( fieldInfo[i].FieldType.IsSubclassOf(typeof(PropertyBase)))
            {

                ((PropertyBase)fieldInfo[i].GetValue(this)).logic = logic;
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

