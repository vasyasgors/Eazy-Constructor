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

    protected Behaviour behaviour;

    private MonoBehaviour container;
    private bool containerHasAssigned = false;

    public bool TryExecute(GameObject self, GameObject other)
    {

       if(owner == ActionOwner.Other)
            gameObject = other;

        if (owner == ActionOwner.Self)
            gameObject = self;


        behaviour = gameObject.GetComponent<Behaviour>();

        // Это имеет смысл, но вряд-ли
      //  LinkProperty();

        if (condition.Execute() == true)
        {
            StartExecute();
            return true;
        }

        return false;
    }

    // Надо как-то оптмизировать это дело, вызывать 1 раз
    /*
    private void LinkProperty()
    {
 

        FieldInfo[] fieldInfo = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

        for(int i = 0; i < fieldInfo.Length; i++)
        {
            Debug.Log(fieldInfo[i].FieldType );

            if ( fieldInfo[i].FieldType ==typeof(VariablePiker))
            {
              
                ((VariablePiker)fieldInfo[i].GetValue(this)).owner = behaviour;
            }
        }
    }*/


    public void SetContainer(MonoBehaviour container)
    {
        this.container = container;
        containerHasAssigned = true;

        hideFlags = HideFlags.HideInInspector;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.update += TryDestroy;
#endif
    }


#if UNITY_EDITOR
    private void TryDestroy()
    {
        if (container == null)
        {
            UnityEditor.EditorApplication.update -= TryDestroy;
            DestroyImmediate(this);
        }
    }

#endif

#if UNITY_EDITOR
    private void OnValidate()
    {
        hideFlags = HideFlags.HideInInspector;
    }
#endif

}

