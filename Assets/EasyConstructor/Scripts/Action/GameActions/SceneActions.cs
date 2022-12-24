using UnityEngine;
using UnityEngine.SceneManagement;

[ActionPath("Scene/LoadScene")]
public class LoadSceneAction : ActionBase
{
    [SerializeField] string _name;
    public override void StartExecute()
    {
        SceneManager.LoadScene(_name);
    }
}

[ActionPath("Scene/RestartScene")]
public class RestartSceneAction : ActionBase
{
    public override void StartExecute()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


