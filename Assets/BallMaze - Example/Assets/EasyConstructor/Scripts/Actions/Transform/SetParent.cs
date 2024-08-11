using UnityEngine;


[ActionPath("Transform/SetParent")]
public class SetParent : ActionBase
{
    [SerializeField] private Transform parent;

    public override void StartExecute()
    {
        gameObject.transform.parent = parent;
    }
}


