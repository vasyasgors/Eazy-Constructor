using UnityEngine;

[ActionPath("Transform/DetachChildren")]
public class DetachChildren : ActionBase
{
    [SerializeField] private TransformPicker soucre;
    public override void StartExecute()
    {
        soucre.Value.DetachChildren();
    }
}


