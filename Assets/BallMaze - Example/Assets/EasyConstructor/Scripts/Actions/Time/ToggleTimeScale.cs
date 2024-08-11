using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ActionPath("Time/ToggleTimeScale")]
public class ToggleTimeScale : ActionBase 
{
    [SerializeField] private ToggleState state;

    private bool _state;

    public override void StartExecute()
    {

        if (Time.timeScale == 0) _state = false;
        if (Time.timeScale == 1) _state = true;
    

        _state = state.ToBool(_state);


        if(_state == false) Time.timeScale = 0;
        if (_state == true) Time.timeScale = 1;
    }
}
