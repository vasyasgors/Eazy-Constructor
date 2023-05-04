using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Audio/PlaySound")]
public class PlaySound : ActionBase
{
    [SerializeField] private bool onShot = false;


    public override void StartExecute()
    {
        if (onShot == true)
            gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);

        if (onShot == false)    
            gameObject.GetComponent<AudioSource>().Play();
        

    }
}
