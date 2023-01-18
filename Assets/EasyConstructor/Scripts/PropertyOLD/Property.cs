using System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace PropertyOld
{
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

    [Serializable] public class PInt : PropertyGeneric<int> { }
    [Serializable] public class PFloat : PropertyGeneric<float> { }
    [Serializable] public class PBool : PropertyGeneric<bool> { }
    [Serializable] public class PVector2 : PropertyGeneric<Vector2> { }
    [Serializable] public class PVector3 : PropertyGeneric<Vector3> { }
    [Serializable] public class PObject : PropertyGeneric<Object> { }
    [Serializable] public class PGameObject : PropertyGeneric<GameObject> { }

}

