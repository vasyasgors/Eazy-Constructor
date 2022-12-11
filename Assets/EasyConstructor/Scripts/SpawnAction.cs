using UnityEngine;

[System.Serializable]
public class SpawnAction : ActionBase
{
    public GameObject Prefab;
    public Transform Position;
    public string SPAWN;

    public  void Execute()
    {
        GameObject g =  GameObject.Instantiate(Prefab);
        g.transform.position = Position.position;


        
    }
}





