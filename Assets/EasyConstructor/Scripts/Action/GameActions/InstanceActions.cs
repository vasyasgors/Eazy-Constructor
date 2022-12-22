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

[ActionPath("Instance/DestoryAction")]
public class DestoryAction : ActionBase
{
    [SerializeField] GameObject _object; [SerializeField] float delay;
    public override void StartExecute()
    {
        Destroy(_object, delay);
    }
}
