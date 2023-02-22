using UnityEngine;

[ActionPath("Instances/Spawn")]
public class Spawn : ActionBase
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform position;
    [SerializeField] private FloatPicker amount;
    [SerializeField] private FloatPicker delay;

    private float timer;

    public override void StartExecute()
    {
        SpawnInstance();
    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;    
    }

    private void SpawnInstance()
    {
        if (timer > 0) return;

        for (int i = 0; i < (int) amount.Value; i++)
        {
            GameObject e = Instantiate(prefab);

            e.transform.position = position.position;
            e.transform.rotation = position.rotation;

            e.SendMessage("Start");
        }
        
        timer = delay.Value;
    }

}
