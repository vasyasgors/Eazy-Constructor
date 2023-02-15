using UnityEngine;


[ActionPath("Transform/JumpToRandomArea")]
public class JumpToRandomArea : ActionBase
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 areaSize;

    public override void StartExecute()
    {
        gameObject.transform.root.position = target.position + new Vector3(
          Random.Range(-areaSize.x * 0.5f, areaSize.x * 0.5f),
          Random.Range(-areaSize.y * 0.5f, areaSize.y * 0.5f),
          Random.Range(-areaSize.z * 0.5f, areaSize.z * 0.5f));
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(target.position, areaSize);
        }
    }
#endif
}


