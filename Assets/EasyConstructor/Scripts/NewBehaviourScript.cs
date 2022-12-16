using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Parent
{

}

[System.Serializable]
public class Child : Parent
{

}

public class NewBehaviourScript : MonoBehaviour
{
    public Parent p;

    public void CreateChild()
    {
        p = new Child(); 
    }
}



