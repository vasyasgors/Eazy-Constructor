using UnityEngine;

[System.Serializable]
public class DestoryAction : ActionBase
{
    public GameObject GameObject;
    public float Delay;

    public override void Execute()
    {
        GameObject.Destroy(GameObject, Delay);
    }

}






