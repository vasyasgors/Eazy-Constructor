using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class Property<T>
{
	public string name;
	public T Value;

    public Property()
    {

    }
}

[Serializable] public class Int : Property<int> { }
[Serializable] public class Float : Property<float> { }
[Serializable] public class Bool : Property<bool> { }
[Serializable] public class Vector2t : Property<Vector2> { }
[Serializable] public class Vector3t : Property<Vector3> { }
[Serializable] public class Objectt : Property<UnityEngine.Object> { }
[Serializable] public class MaterialT : Property<Material> { }




public class Properties : MonoBehaviour 
{
	public Int[] inte;

    public void TryLinkProperty(ref Int property)
    {
        for(int i = 0; i < inte.Length; i++)
        {
            if (inte[i].name == property.name)
            {
                property = inte[i];
                return;
            }    
        }
    }
}

/*
 * 
 * public class Int   { public int Value; }
public class Float { public float Value; }
public class Bool  { public bool Value; }
public class Vector2t  { public Vector2 Value; }
public class Vector3t  { public Vector3 Value; }
public class Objectt { public UnityEngine.Object Value; }*/
