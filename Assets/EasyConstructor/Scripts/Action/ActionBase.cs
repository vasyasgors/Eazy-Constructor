using UnityEngine;

public abstract class ActionBase : MonoBehaviour
{
    [SerializeField]
    private Condition condition;

    [HideInInspector] public bool HideProperties;

    public Condition Condition { get { return condition; } }

    public virtual void StartExecute() { }

    public virtual string GetHideString() { return name; }


    public bool TryExecute()
    {
        if (condition.Execute() == true)
        {
            StartExecute();
            return true;
        }

        return false;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        //   hideFlags = HideFlags.HideInInspector;
    }
#endif

}

