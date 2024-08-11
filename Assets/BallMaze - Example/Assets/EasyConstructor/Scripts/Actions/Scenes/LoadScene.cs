using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ActionPath("Scenes/LoadScene")]
public class LoadScene : ActionBase
{
    [SerializeField] private string sceneName;

    public override void StartExecute()
    {
        SceneManager.LoadScene(sceneName);
    }
}
