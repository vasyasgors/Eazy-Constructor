using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ComponentName
{
    Behaviour,
    MeshRenderer,
    Collider,
    Animator
}

[ActionPath("Instances/ToggleComponent")]
public partial class ToggleComponent : ActionBase
{
    [SerializeField] private ComponentName _component;
    [SerializeField] private ToggleState state;

    public override void StartExecute()
    {

        if (_component == ComponentName.Behaviour) gameObject.GetComponent<Behaviour>().enabled = state.ToBool(gameObject.GetComponent<Behaviour>().enabled);
        if (_component == ComponentName.MeshRenderer) gameObject.GetComponent<MeshRenderer>().enabled = state.ToBool(gameObject.GetComponent<MeshRenderer>().enabled);
        if (_component == ComponentName.Collider) gameObject.GetComponent<Collider>().enabled = state.ToBool(gameObject.GetComponent<Collider>().enabled);
        if (_component == ComponentName.Animator) gameObject.GetComponent<Animator>().enabled = state.ToBool(gameObject.GetComponent<Animator>().enabled);
    }
}
