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
    public string variableName;

    [SerializeField] public Logic logic;

}




[Serializable] public class PFloat : PropertyGeneric<float> { }

[Serializable]
public class PropertyGeneric<T1> : PropertyBase 
{
    [SerializeField] private T1 value;
   



    private Variable cachedVariable;

    public T1 GetValue()
    {
        /*
        if (mode == PropertyMode.Variable && cachedVariable == null)
            throw new NullReferenceException();*/

        if (mode == PropertyMode.Variable)
        {
            return logic.GetVariable(variableName).GetValue<T1>();
        }

            return value;
    }


    public override string ToString()
    {
        if (mode == PropertyMode.Variable)
        {
            if (logic != null)
                return "[" + logic.GetVariable(variableName).GetValue<T1>().ToString() + "]";
            
            return variableName;
        }

        return value.ToString();
    }

    /*
    public T1 Value
    {
        get
        {

            
            if (mode == PropertyMode.Variable && variable == null)
                throw new NullReferenceException();

            if (mode == PropertyMode.Variable) return variable.boolValue;

            return value;
        }
        
        set
        {
            if (mode == PropertyMode.Variable && variable == null) throw new NullReferenceException();

            if (mode == PropertyMode.Variable) variable.Value = value;
           
            this.value = value;

        }

    }
    */
}



/*
[Serializable] public class PFloat : PropertyGeneric<float, FloatVariable> { }
[Serializable] public class PInt : PropertyGeneric<int, IntVariable> { }
[Serializable] public class PBool : PropertyGeneric<bool, BoolVariable> { }
[Serializable] public class PVector2 : PropertyGeneric<Vector2, Vector2Variable> { }
[Serializable] public class PVector3 : PropertyGeneric<Vector3, Vector3Variable> { }
[Serializable] public class PObject : PropertyGeneric<Object, ObjectVariable> { }
[Serializable] public class PGameObject : PropertyGeneric<GameObject, GameObjectVariable> { }



*/
