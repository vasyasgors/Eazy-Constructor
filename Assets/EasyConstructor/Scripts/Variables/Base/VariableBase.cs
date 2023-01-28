using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;


public enum VariableTypeNames
{
    Int,
    Float,
    Bool,
    String,
    Color,
    Vector2,
    Vector3,
    Transform,
    GameObject
}

[Serializable]
public class Variable
{
    private const string DefaultVariableName = "VarName";

    [SerializeField] private string name;
    [SerializeField] private VariableTypeNames typeName;

    public string Name { get { return name; } }

    [HideInInspector] public bool ToRemove;

    public int intValue;
    public float floatValue;
    public bool boolValue;
    public string stringValue;
    public Color colorValue;
    public Vector2 vector2Value;
    public Vector3 vector3Value;
    public Object objectValue;

    public Variable(VariableTypeNames typeName)
    {
        name = DefaultVariableName;
        this.typeName = typeName;
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

    public Type GetTypeByName()
    {
        return GetTypeByName(typeName);
    }

    public static Type GetTypeByName(VariableTypeNames typeName)
    {
        if (typeName == VariableTypeNames.Int) return typeof(int);
        if (typeName == VariableTypeNames.Float) return typeof(float);
        if (typeName == VariableTypeNames.Bool) return typeof(bool);
        if (typeName == VariableTypeNames.String) return typeof(string);
        if (typeName == VariableTypeNames.Color) return typeof(Color);
        if (typeName == VariableTypeNames.Vector2) return typeof(Vector3);
        if (typeName == VariableTypeNames.Vector3) return typeof(Vector2);
        if (typeName == VariableTypeNames.Transform) return typeof(Transform);
        if (typeName == VariableTypeNames.GameObject) return typeof(GameObject);

        return typeof(object);
    }
}
