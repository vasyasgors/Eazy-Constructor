using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

// To unity inspector hack
[System.Serializable]
public class Variable
{
    [SerializeField] private string name;
    [SerializeField] private string type;

    public string Name { get { return name; } }

    public int intValue;
    public float floatValue;
    public bool boolValue;
    public string stringValue;
    public Color colorValue;
    public Vector2 vector2Value;
    public Vector3 vector3Value;
    public Object objectValue;

    private Type cacheType;

    public Variable(string type)
    {
        this.type = type;

        cacheType = GetType(type);
    }


    public T GetValue<T>()
    {
       
        if (typeof(T) == typeof(int)) return  (T) ((object) intValue);
        if (typeof(T) == typeof(float)) return  (T) ((object) floatValue);
        if (typeof(T) == typeof(bool)) return  (T) ((object) boolValue);
        if (typeof(T) == typeof(string)) return  (T) ((object) stringValue);
        if (typeof(T) == typeof(Color)) return  (T) ((object) colorValue);
        if (typeof(T) == typeof(Vector2)) return  (T) ((object) vector2Value);
        if (typeof(T) == typeof(Vector3)) return  (T) ((object) vector3Value);
        if (typeof(T).IsSubclassOf(typeof(Object))) return  (T)(object)(objectValue);

        return (T) new object();
        
    }
    // Сделать автоматом вычесление типа

    // Сделать быстрым
    public static Type GetType(string name)
    {
        if (name == "") return null;

        Debug.Log("Долго считаем!");
        return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == name);
    }
}



/*
public abstract class VariableBase<T> : Variable
{
     public T Value;

    protected VariableBase(string type) : base(type)
    {
    }
}

[System.Serializable]
public class IntVariable : VariableBase<int> { }
public class BoolVariable : VariableBase<bool> { }
public class FloatVariable : VariableBase<float> { }


public class GameObjectVariable : VariableBase<GameObject> { }
[System.Serializable]
public class ObjectVariable : VariableBase<Object> { }
public class Vector2Variable : VariableBase<Vector2> { }
public class Vector3Variable : VariableBase<Vector3> { }*/









