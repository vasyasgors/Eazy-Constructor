using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Instances/FindNearestObjectWithTag")]
public class FindNearestObjectWithTag : ActionBase
{
    [SerializeField] [VariablePickerFilter(VariableTypes.Transform)] private VariablePicker variable;
	[SerializeField] private FloatPicker distance;
	[SerializeField] private string _tag;

    public override void StartExecute()
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag(_tag);

        if (objects.Length == 0) return;

        float dist = distance.Value;

        GameObject nearestObject = objects[0];

        for(int i = 0; i < objects.Length; i++)
        {
            if(Vector3.Distance(gameObject.transform.position, objects[i].transform.position) < dist)
            {
                dist = Vector3.Distance(gameObject.transform.position, objects[i].transform.position);
                nearestObject = objects[i];
            }
  
        }


        variable.Variable.Value = (object)nearestObject.transform;
    }
}
