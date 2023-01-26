using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TransformActions
{
    public const string Category = "Transform/";

    [ActionPath(Category + "SecondAction")]
    public class SecondAction : ActionBase
    {

        public PFloat speed;

        public Space space;
        public override void StartExecute()
        {

            speed.logic = logic;


  

            gameObject.transform.Translate(Vector3.up * speed.GetValue() * Time.deltaTime);
        }
    }

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
