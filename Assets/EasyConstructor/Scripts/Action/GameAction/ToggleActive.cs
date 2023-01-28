using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("ToggleActive")]
public class ToggleActive : ActionBase
{
	public enum ToggleState
    {
		On,
		Off,
		Toogle
    }

    [SerializeField] private GameObjectProp target;
    [SerializeField] private ToggleState state;

    public override void StartExecute()
    {
        if (state == ToggleState.Toogle) target.Value.SetActive(!target.Value.activeSelf);
        if (state == ToggleState.On) target.Value.SetActive(true);
        if (state == ToggleState.Off) target.Value.SetActive(false);
    }
}
