using UnityEngine;

// Добавить задержку

public abstract class ActionBase : MonoBehaviour
{
    [SerializeField]
    private Condition condition;

    public Condition Condition { get { return condition; } }

    public virtual void StartExecute() { }

    void Awake()
    {
        Debug.Log(GetType());
    }

    public bool TryExecute()
    {
        if(condition.Execute() == true)
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






