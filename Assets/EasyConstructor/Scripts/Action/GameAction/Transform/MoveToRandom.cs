using UnityEngine;

[ActionPath("Transform/MoveToRandom")]
public class MoveToRandom : ActionBase
{
    [SerializeField] private Vector3Prop areaSize;
    [SerializeField] private FloatProp speed;
    [SerializeField] private BoolProp loop;
    [SerializeField] private bool useDeltaTime;


    private Vector3 target;

    public override void StartExecute()
    {

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, speed.Value * (useDeltaTime == true ? Time.deltaTime : 1));

        if (loop.Value == true && gameObject.transform.position == target)
            UpdateTarget();
    }

    private void UpdateTarget()
    {
        target = new Vector3(
            Random.Range(-areaSize.Value.x * 0.5f, areaSize.Value.x * 0.5f),
            Random.Range(-areaSize.Value.y * 0.5f, areaSize.Value.y * 0.5f),
            Random.Range(-areaSize.Value.z * 0.5f, areaSize.Value.z * 0.5f));
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, areaSize.Value);
    }
#endif
}


