using UnityEngine;

[ActionPath("Instance/Spawn")]
public class SpawnAction : ActionBase
{
    [SerializeField] Transform prefab; [SerializeField] Transform position; 
    public override void StartExecute()
    {
        Instantiate(prefab).transform.position = transform.position;
    }
}
