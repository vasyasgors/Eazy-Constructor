using UnityEngine;
using UnityEngine.AI;

[ActionPath("AI/SetDistination")]
public class SetDistination : ActionBase 
{
    [SerializeField] private TransformPicker target;
    [SerializeField] private NavMeshAgent agent;

    public override void StartExecute()
    {
        agent.SetDestination(target.Value.position);

    }
}
