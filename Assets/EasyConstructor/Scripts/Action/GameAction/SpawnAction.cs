using UnityEngine;

[System.Serializable]
public class SpawnAction : ActionBase
{
    public GameObject Prefab;
    public Transform Position;

    public bool IsSelfPosition;

    public override void StartExecute()
    {
        //if (IsSelfPosition == true)
         //   Instantiate(Prefab).transform.position = transform.position;
        //else
           // Instantiate(Prefab).transform.position = Position.position;
    }
}





