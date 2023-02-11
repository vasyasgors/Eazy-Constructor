using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ActionPath("ReloadScene")]
public class ReloadScene : ActionBase 
{

    public override void StartExecute()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
