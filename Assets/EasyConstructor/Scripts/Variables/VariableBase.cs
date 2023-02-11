using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;


public enum VariableTypeNames
{
    Number,
    Toggle
  /*String,
    Color,
    Vector2,
    Vector3,
    Transform,
    GameObject*/
}

[Serializable]
public class Variable
{
    private const string DefaultVariableName = "VarName";

    [SerializeField] private string name;
    [SerializeField] private VariableTypeNames typeName;

    public string Name { get { return name; } }

    [HideInInspector] public bool ToRemove;


    public enum DisplayMode
    {
        Edit,
        Value
    }

    public DisplayMode Mode;

    public float floatValue;
    public bool boolValue;

    /*
    public int intValue;
    public string stringValue;
    public Color colorValue;
    public Vector2 vector2Value;
    public Vector3 vector3Value;
    public Object objectValue;*/

    public Variable(VariableTypeNames typeName)
    {
        name = DefaultVariableName;
        this.typeName = typeName;
    }

    public void SetType(VariableTypeNames typeName)
    {
        this.typeName = typeName;
    }

    public void SetName(string name)
    {
        this.name = name;
    }


    public T GetValue<T>()
    {
        if (typeof(T) == typeof(float)) return  (T) ((object) floatValue);
        if (typeof(T) == typeof(bool)) return  (T) ((object) boolValue);
        /*
        if (typeof(T) == typeof(string)) return  (T) ((object) stringValue);
        if (typeof(T) == typeof(Color)) return  (T) ((object) colorValue);
        if (typeof(T) == typeof(Vector2)) return  (T) ((object) vector2Value);
        if (typeof(T) == typeof(Vector3)) return  (T) ((object) vector3Value);
        if (typeof(T).IsSubclassOf(typeof(Object))) return  (T)(object)(objectValue);
        */

        return (T) new object();
        
    }

    public void SetValue(object val)
    {
        if (typeName == VariableTypeNames.Number) floatValue = (float) val;
        if (typeName == VariableTypeNames.Toggle) boolValue = (bool) val;
    }




    public Type GetTypeByName()
    {
        return GetTypeByName(typeName);
    }

    public bool CompareType(string type)
    {
        if (type == "float" && typeName == VariableTypeNames.Number) return true;
        if (type == "bool" && typeName == VariableTypeNames.Toggle) return true;
        /*
        if (type == "string" && typeName == VariableTypeNames.String) return true;
        if (type == "Color" && typeName == VariableTypeNames.Color) return true;
        if (type == "Vector2" && typeName == VariableTypeNames.Vector2) return true;
        if (type == "Vector3" && typeName == VariableTypeNames.Vector3) return true;
        if (type == "Transform" && typeName == VariableTypeNames.Transform) return true;
        if (type == "GameObject" && typeName == VariableTypeNames.GameObject) return true;
        */

        return false;
    }

    public static Type GetTypeByName(VariableTypeNames typeName)
    {
        if (typeName == VariableTypeNames.Number) return typeof(float);
        if (typeName == VariableTypeNames.Toggle) return typeof(bool);
        /*
        if (typeName == VariableTypeNames.String) return typeof(string);
        if (typeName == VariableTypeNames.Color) return typeof(Color);
        if (typeName == VariableTypeNames.Vector2) return typeof(Vector2);
        if (typeName == VariableTypeNames.Vector3) return typeof(Vector3);
        if (typeName == VariableTypeNames.Transform) return typeof(Transform);
        if (typeName == VariableTypeNames.GameObject) return typeof(GameObject);
        */

        return typeof(object);
    }


}
