using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public partial class TransformActions
{
    public const string Category = "Transform/";

}






[ActionPath("Variable /ChangeFloatVariable")]
public class SetFloatVariable : ActionBase
{
    
    [SerializeField] public string variableName = "";
    [SerializeField] private float delta;
   // [SerializeField] public bool relative;

    public override void StartExecute()
    {

        logic.GetVariable(variableName).floatValue += delta;

        /*
        if (relative == false)
            variable1.Value = float.Parse(value);

        if (relative == true)
        {
            variable1.Value += float.Parse(value);
        }
        */

    }
}
