using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[ActionPath("Variable /AssignVariable")]
public class AssignVariable : ActionBase
{



    [SerializeField] [OnlyVariable] private VariableField variable;
    [SerializeField] private Variable value;



    // [SerializeField] public bool relative;






    public override void StartExecute()
    {
        //gameObject = target.Value;
        //behaviour = target.Value.GetComponent<Behaviour>();

        /*
        if (variable.mode == PropertyMode.Variable)
            behaviour.GetVariable(variable.variableName).floatValue += delta;

        if (variable.mode == PropertyMode.GlobalVariable)
            variable.globalVariable.Variable.floatValue += delta;
        */


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
