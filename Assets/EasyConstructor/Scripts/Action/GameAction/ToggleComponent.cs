using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("ToggleComponent")]
public class ToggleComponent : ActionBase
{

	[SerializeField] private ComponentPicker component;
	[SerializeField] private ToggleState state;

	
}
