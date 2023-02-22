using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Instances/ToggleActive")]
public partial class ToggleActive : ActionBase
{
    [SerializeField] private ToggleState state;

    public override void StartExecute()
    {
        gameObject.SetActive(state.ToBool(gameObject.activeSelf));
    }
}
