using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ActionPath("Mouse/ToggleCursor")]
public class ToggleCursor : ActionBase
{
    [SerializeField] private ToggleState state;

    private bool corsourVisible;

    public override void StartExecute()
    {

        corsourVisible = state.ToBool(corsourVisible);

        if(corsourVisible == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = corsourVisible;
        }

        if (corsourVisible == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = corsourVisible;
        }
    }
}
