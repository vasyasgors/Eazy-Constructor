using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ActionPath("Physics/RaycastLine")]
public class RaycastLine : ActionBase
{
    [SerializeField] private TransformPicker target;

    [SerializeField] [VariablePickerFilter(VariableTypes.Toggle)] private VariablePicker result;

    public override void StartExecute()
    {

        RaycastHit[] allHits =  Physics.RaycastAll(gameObject.transform.position, 
            (target.Value.position - gameObject.transform.position).normalized,
            (target.Value.position - gameObject.transform.position).magnitude);

        bool res = true;

        for (int i = 0; i < allHits.Length; i++)
        {
            if (allHits[i].transform != gameObject.transform && allHits[i].transform != target.Value)
            {
                res = false;
                break;
            }
        }
        result.Variable.Value = (object) res;
    }


#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        if(gameObject != null)
            Gizmos.DrawLine(gameObject.transform.position, target.Value.position);

    }
#endif
}
