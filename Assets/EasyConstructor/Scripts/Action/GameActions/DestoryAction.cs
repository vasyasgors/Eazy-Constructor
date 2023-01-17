using UnityEngine;

[ActionPath("Instance/DestoryAction")]
public class DestoryAction : ActionBase
{
    [SerializeField] GameObjectt _object; [SerializeField] Float delay;
    public override void StartExecute()
    {
        Destroy(_object.Value, delay.Value);
    }
}
