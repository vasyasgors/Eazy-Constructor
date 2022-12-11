using UnityEngine;

[System.Serializable]
public class DestoryCommand : CommandBase
{
    public GameObject GameObject;
    public float Delay;

    public override void Execute()
    {
        GameObject.Destroy(GameObject, Delay);
    }

}






