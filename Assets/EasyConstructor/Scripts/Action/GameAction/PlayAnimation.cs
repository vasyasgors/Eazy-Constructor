using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ActionPath("Animator/PlayAnimation")]
[RequireComponent(typeof(Animator))]
public class PlayAnimation : ActionBase
{
    [SerializeField] private string _name;

    public override void StartExecute()
    {
        gameObject.GetComponent<Animator>().Play(_name);
    }
}
