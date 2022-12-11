using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelAction : ActionBase
{

	public string LevelName;

    public override void StartExecute()
    {

        Application.LoadLevel(LevelName);
    }
}
