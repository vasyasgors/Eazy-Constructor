using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

// To unity inspector hack
[System.Serializable]
public class Variable
{
    public string name;
    public string type;
    public Object unityObject;
    public int intValue;

    public static Type GetType(string name)
    {
        if (name == "") return null;

        return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == name);
    }
}








public abstract class VariableBase<T> : Variable
{
     public T Value;
}

[System.Serializable]
public class IntVariable : VariableBase<int> { }
public class BoolVariable : VariableBase<bool> { }
public class FloatVariable : VariableBase<float> { }


public class GameObjectVariable : VariableBase<GameObject> { }
[System.Serializable]
public class ObjectVariable : VariableBase<Object> { }
public class Vector2Variable : VariableBase<Vector2> { }
public class Vector3Variable : VariableBase<Vector3> { }









