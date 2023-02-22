using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Instances/ToggleObjectActive")]
public partial class ToggleObjectActive : ActionBase
{
    [SerializeField] private ToggleState state;

    public override void StartExecute()
    {
        gameObject.SetActive(state.ToBool(gameObject.activeSelf));
    }
}
