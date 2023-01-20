using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TransformActions
{
    public const string Category = "Transform/";

    [ActionPath(Category + "SecondAction")]
    public class SecondAction : ActionBase
    {
        public PVector3 direction;  public PFloat speed; public Space space;
        public override void StartExecute()
        {
            gameObject.transform.Translate(direction.Value * speed.Value * Time.deltaTime);
        }
    }

}

[ActionPath("Variable /ChangeFloatVariable")]
public class SetFloatVariable : ActionBase
{
    [SerializeField] public FloatVariable variable1;
   // [SerializeField] public string value;
   // [SerializeField] public bool relative;

    public override void StartExecute()
    {
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
