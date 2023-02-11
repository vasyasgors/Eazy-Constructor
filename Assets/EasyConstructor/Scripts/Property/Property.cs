using System;
using UnityEngine;
using Object = UnityEngine.Object;

public enum PropertyMode
{
    Value,
    Variable,
    GlobalVariable
}

[Serializable]
public class PropertyBase
{
    public PropertyMode mode;

    public string variableName;
    public VariableTypeNames variableType;

    public GlobalVariable globalVariable;


    [SerializeField] public Behaviour behaviour;

}




[Serializable]
public class PropertyGeneric<T1> : PropertyBase 
{
    [SerializeField] private T1 value;
   
    public T1 Value
    {
        get
        {
            if (mode == PropertyMode.Variable)
            {
                return behaviour.GetVariable(variableName).GetValue<T1>();
            }

            if (mode == PropertyMode.GlobalVariable)
            {
                return globalVariable.Variable.GetValue<T1>();
            }

            return value;
        }

  


    }

    public override string ToString()
    {
        if (mode == PropertyMode.Variable)
        {
            if (behaviour != null)
                return behaviour.GetVariable(variableName).GetValue<T1>().ToString().ToString();
            
            return variableName;
        }

        return value.ToString();
    }
}

// Лютый костыль, так как object не сериализуется
[Serializable] public class VariableField : PropertyGeneric<int> { }

[Serializable] public class IntProp : PropertyGeneric<int> { }
[Serializable] public class FloatProp : PropertyGeneric<float> { }
[Serializable] public class BoolProp : PropertyGeneric<bool> { }
[Serializable] public class StringProp : PropertyGeneric<string> { }
[Serializable] public class ColorProp : PropertyGeneric<Color> { }
[Serializable] public class Vector2Prop : PropertyGeneric<Vector2> { }
[Serializable] public class Vector3Prop : PropertyGeneric<Vector3> { }
[Serializable] public class TransformProp : PropertyGeneric<Transform> { }
[Serializable] public class GameObjectProp : PropertyGeneric<GameObject> { }

