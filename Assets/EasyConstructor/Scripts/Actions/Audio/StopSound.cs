using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Audio/StopSound")]
public class StopSound : ActionBase
{
    public override void StartExecute()
    {
        gameObject.GetComponent<AudioSource>().Stop();
    }

}
