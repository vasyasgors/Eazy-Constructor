using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ActionPath("Time/SetTimeScale")]
public class SetTimeScale : ActionBase 
{
    [SerializeField] private FloatPicker timeScale;

    public override void StartExecute()
    {
        Time.timeScale = timeScale.Value;
    }
}
