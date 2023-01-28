using UnityEngine;


[ActionPath("Transform/JumpToRandomArea")]
public class JumpToRandomArea : ActionBase
{
    [SerializeField] private TransformProp target;
    [SerializeField] private Vector3Prop areaSize;

    public override void StartExecute()
    {
        gameObject.transform.root.position = target.Value.position + new Vector3(
          Random.Range(-areaSize.Value.x * 0.5f, areaSize.Value.x * 0.5f),
          Random.Range(-areaSize.Value.y * 0.5f, areaSize.Value.y * 0.5f),
          Random.Range(-areaSize.Value.z * 0.5f, areaSize.Value.z * 0.5f));
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(target.Value.position, areaSize.Value);
        }
    }
#endif
}


