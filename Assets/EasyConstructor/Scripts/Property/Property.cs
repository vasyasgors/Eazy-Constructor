using System;
using UnityEngine;

public enum PropertyDrawMode
{
    Setup,
    OnlyValue,
    Linked
}

[Serializable]
public class PropertyBase
{
    public PropertyDrawMode drawMode = PropertyDrawMode.OnlyValue;
    public string Name = "PropertyName";

    public PropertyBase()
    {
        Name = "PropertyName";
    }
}


[Serializable]
public class PropertyGeneric<T> : PropertyBase
{
	
	public T Value;
}

[Serializable] public class Int : PropertyGeneric<int> { }
[Serializable] public class Float : PropertyGeneric<float> { }
[Serializable] public class Bool : PropertyGeneric<bool> { }
[Serializable] public class Vector2t : PropertyGeneric<Vector2> { }
[Serializable] public class Vector3t : PropertyGeneric<Vector3> { }
[Serializable] public class Objectt : PropertyGeneric<UnityEngine.Object> { }
[Serializable] public class GameObjectt : PropertyGeneric<UnityEngine.GameObject> { }


