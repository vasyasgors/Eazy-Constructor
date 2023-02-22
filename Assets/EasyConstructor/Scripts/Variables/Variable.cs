using System;
using UnityEngine;
using Object = UnityEngine.Object;

public enum VariableTypes
{
    Number,
    Toggle,
    String,
    Transform,
    Any
}

[Serializable]
public class Variable
{
    public string name;
    public VariableTypes type;

    [SerializeField] private float floatValue;
    [SerializeField] private bool boolValue;
    [SerializeField] private string stringValue;
    [SerializeField] private Object objectValue;


    public object Value
    {
        get
        {
            if (type == VariableTypes.Number) return floatValue;
            if (type == VariableTypes.Toggle) return boolValue;
            if (type == VariableTypes.String) return stringValue;
            if (type == VariableTypes.Transform) return objectValue;

            return null;
        }

        set
        {
            if (type == VariableTypes.Number) floatValue = (float) value;
            if (type == VariableTypes.Toggle) boolValue = (bool) value;
            if (type == VariableTypes.String) stringValue = (string) value;
            if (type == VariableTypes.Transform) objectValue = (Transform) value;
        }
    }

    public Variable(VariableTypes type)
    {
        this.name = "Variable Name";
        this.type = type;
    }


    public static VariableTypes GetVariableType(Type type)
    {
        if (type == typeof(float)) return VariableTypes.Number;
        if (type == typeof(bool)) return VariableTypes.Toggle;
        if (type == typeof(string)) return VariableTypes.String;
        if (type == typeof(Transform)) return VariableTypes.Transform;


        return VariableTypes.Any;
    }

    public static VariableTypes GetVariableType(string type)
    {
        if (type == "float") return VariableTypes.Number;
        if (type == "bool") return VariableTypes.Toggle;
        if (type == "string") return VariableTypes.String;
        if (type == "PPtr<$Transform>") return VariableTypes.Transform;

        return VariableTypes.Any;
    }


    public static Type GetRealVariableType(VariableTypes type)
    {
        if (type == VariableTypes.Number) return typeof(float);
        if (type == VariableTypes.Toggle) return typeof(bool);
        if (type == VariableTypes.String) return typeof(string);
        if (type == VariableTypes.Transform) return typeof(Transform);

        return typeof(object);
    }


    // TEMP
    [HideInInspector] public bool ToRemove;
}
