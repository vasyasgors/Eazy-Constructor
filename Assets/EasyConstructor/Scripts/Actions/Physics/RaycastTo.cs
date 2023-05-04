using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ActionPath("Physics/RaycastTo")]
public class RaycastTo : ActionBase
{
    [SerializeField] private TransformPicker target;
    [SerializeField] private FloatPicker distance;

    [SerializeField] [VariablePickerFilter(VariableTypes.Toggle)] private VariablePicker result;

    public override void StartExecute()
    {
        RaycastHit[] allHits =  Physics.RaycastAll(gameObject.transform.position, 
            (target.Value.position - gameObject.transform.position).normalized,
           (float) distance.Value);


        bool res = false;

        if (allHits.Length == 1 && allHits[0].transform == target.Value)
            res = true;

        result.Variable.Value = (object) res;
    }


#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        if (gameObject != null)
            Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position + (target.Value.position - gameObject.transform.position).normalized * (float)distance.Value);
     
    }
#endif
}
