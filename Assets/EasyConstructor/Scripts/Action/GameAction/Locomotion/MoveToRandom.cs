using UnityEngine;

[ActionPath("Locomotion/MoveToRandom")]
public class MoveToRandom : ActionBase
{
    [SerializeField] private Vector3 areaSize;
    [SerializeField] private FloatPicker speed;
    [SerializeField] private bool loop;
    [SerializeField] private bool smoothly = true;
    [SerializeField] private bool relative;

    private Vector3 target;
    private bool targetUpdated;

    public override void StartExecute()
    {
        UpdateTarget();

        if (smoothly == true)
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, speed.Value * Time.deltaTime);
        else
        {
            gameObject.transform.position = target;
            Reached();
        }


        if (gameObject.transform.position == target)
        {

            Reached();
        }
    }

    private void Reached()
    {
        targetUpdated = false;

        if(loop == true)
            UpdateTarget();
    }

    private void UpdateTarget()
    {
        if (targetUpdated == true) return;

        if (relative == true)
            target = new Vector3(
            Random.Range(gameObject.transform.position.x + -areaSize.x * 0.5f, gameObject.transform.position.x + areaSize.x * 0.5f),
            Random.Range(gameObject.transform.position.y + -areaSize.y * 0.5f, gameObject.transform.position.y + areaSize.y * 0.5f),
            Random.Range(gameObject.transform.position.z + -areaSize.z * 0.5f, gameObject.transform.position.z + areaSize.z * 0.5f));

        if (relative == false)
            target = new Vector3(
            Random.Range(-areaSize.x * 0.5f, areaSize.x * 0.5f),
            Random.Range(-areaSize.y * 0.5f, areaSize.y * 0.5f),
            Random.Range(-areaSize.z * 0.5f, areaSize.z * 0.5f));

       

        targetUpdated = true;
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        if(relative == true)
            Gizmos.DrawWireCube(transform.position, areaSize);
        else
            Gizmos.DrawWireCube(Vector3.zero, areaSize);
    }
#endif
}


