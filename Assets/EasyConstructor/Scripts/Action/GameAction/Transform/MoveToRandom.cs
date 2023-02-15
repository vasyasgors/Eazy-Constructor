using UnityEngine;

[ActionPath("Transform/MoveToRandom")]
public class MoveToRandom : ActionBase
{
    [SerializeField] private Vector3 areaSize;
    [SerializeField] private FloatPicker speed;
    [SerializeField] private BoolPicker loop;
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
            Random.Range(-areaSize.x * 0.5f, areaSize.x * 0.5f),
            Random.Range(-areaSize.y * 0.5f, areaSize.y * 0.5f),
            Random.Range(-areaSize.z * 0.5f, areaSize.z * 0.5f));
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, areaSize);
    }
#endif
}


