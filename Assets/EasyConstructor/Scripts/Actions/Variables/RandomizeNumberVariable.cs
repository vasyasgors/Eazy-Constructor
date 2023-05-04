using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[ActionPath("Variable/RandomizeVariable")]
public class RandomizeNumberVariable : ActionBase
{ 
    [SerializeField] [VariablePickerFilter(VariableTypes.Number)] private VariablePicker variable;

    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;
    [SerializeField] private bool integer;

    public override void StartExecute()
    {

        float rnd = Random.Range(minValue, maxValue);
        variable.Variable.Value = integer == true ? (int)rnd : rnd;
    }
        


}
