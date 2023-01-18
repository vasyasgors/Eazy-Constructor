using UnityEngine;

[ActionPath("Instance/DestoryAction")]
public class DestoryAction : ActionBase
{
   // [SerializeField] PGameObject _object; [SerializeField] PFloat delay;
    public override void StartExecute()
    {
        //Destroy(_object.Value, delay.Value);
    }
}
