using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Amimator/PlayAnimation")]
public class PlayAnimation : ActionBase 
{
    [SerializeField] private string animationName;

    public override void StartExecute()
    {
        gameObject.GetComponent<Animator>().Play(animationName);

        
    }
}
