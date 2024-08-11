using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum ComponentName
{
    Behaviour,
    Light,
    MeshRenderer,
    Collider,
    Animator,
    Image,
    SpriteRenderer
}

[ActionPath("Instances/ToggleComponent")]
public partial class ToggleComponent : ActionBase
{
    [SerializeField] private ComponentName _component;
    [SerializeField] private ToggleState state;

    public override void StartExecute()
    {

        if (_component == ComponentName.Behaviour) gameObject.GetComponent<Behaviour>().enabled = state.ToBool(gameObject.GetComponent<Behaviour>().enabled);
        if (_component == ComponentName.Light) gameObject.GetComponent<Light>().enabled = state.ToBool(gameObject.GetComponent<Light>().enabled);
        if (_component == ComponentName.MeshRenderer) gameObject.GetComponent<MeshRenderer>().enabled = state.ToBool(gameObject.GetComponent<MeshRenderer>().enabled);
        if (_component == ComponentName.Collider) gameObject.GetComponent<Collider>().enabled = state.ToBool(gameObject.GetComponent<Collider>().enabled);
        if (_component == ComponentName.Image) gameObject.GetComponent<Image>().enabled = state.ToBool(gameObject.GetComponent<Image>().enabled);
        if (_component == ComponentName.SpriteRenderer) gameObject.GetComponent<SpriteRenderer>().enabled = state.ToBool(gameObject.GetComponent<SpriteRenderer>().enabled);
    }
}
