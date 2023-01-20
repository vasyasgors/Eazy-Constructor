using System;
using UnityEngine;
using Object = UnityEngine.Object;

public enum PropertyMode
{
    Value,
    Variable
}

[Serializable]
public class PropertyBase
{
    public PropertyMode mode = PropertyMode.Value;
}

[Serializable]
public class PropertyGeneric<T1, T2> : PropertyBase where T2 : VariableBase<T1>
{
    [SerializeField] private T1 value;
    [SerializeField] private T2 variable;

    public T1 Value
    {
        get
        {
            if (mode == PropertyMode.Variable && variable == null)
                throw new NullReferenceException();

            if (mode == PropertyMode.Variable) return variable.Value;

            return value;
        }

        set
        {
            if (mode == PropertyMode.Variable && variable == null) throw new NullReferenceException();

            if (mode == PropertyMode.Variable) variable.Value = value;
           
            this.value = value;

        }
    }
}

[Serializable] public class PFloat : PropertyGeneric<float, FloatVariable> { }
[Serializable] public class PInt : PropertyGeneric<int, IntVariable> { }
[Serializable] public class PBool : PropertyGeneric<bool, BoolVariable> { }
[Serializable] public class PVector2 : PropertyGeneric<Vector2, Vector2Variable> { }
[Serializable] public class PVector3 : PropertyGeneric<Vector3, Vector3Variable> { }
[Serializable] public class PObject : PropertyGeneric<Object, ObjectVariable> { }
[Serializable] public class PGameObject : PropertyGeneric<GameObject, GameObjectVariable> { }




