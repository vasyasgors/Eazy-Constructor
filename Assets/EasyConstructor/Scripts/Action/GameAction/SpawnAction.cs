using UnityEngine;


public class SpawnAction : ActionBase
{
    public GameObject Prefab;
    public Transform Position;
    public float delay;

    public bool IsSelfPosition;


    float t = 0;

    void Start()
    {
        enabled = false;
    }

    void Update()
    {
        t += Time.deltaTime;


   
        if(t >= delay)
        {
            if (IsSelfPosition == true)
                Instantiate(Prefab).transform.position = transform.position;
            else
                Instantiate(Prefab).transform.position = Position.position;

            t = 0;
            enabled = false;
        }
    }

    public override void StartExecute()
    {
        if (enabled == true) return;
        t = 0;
        enabled = true;
    }
}





