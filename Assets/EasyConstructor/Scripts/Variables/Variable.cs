using System;
using UnityEngine;

public enum VariableTypes
{
    Number,
    Toggle,
    Any
}

[Serializable]
public class Variable
{
    public string name;
    public VariableTypes type;

    [SerializeField] private float floatValue;
    [SerializeField] private bool boolValue;

    public object Value
    {
        get
        {
            if (type == VariableTypes.Number) return floatValue;
            if (type == VariableTypes.Toggle) return boolValue;

            return null;
        }

        set
        {
            if (type == VariableTypes.Number) floatValue = (float)value;
            if (type == VariableTypes.Toggle) boolValue = (bool)value;
        }
    }

    public Variable(VariableTypes type)
    {
        this.name = "Variable Name";
        this.type = type;
    }

    // Надо подумать как лучше сделать конвертацию типов
    public static VariableTypes GetVariableTypeFormType(Type type)
    {
        if (type == typeof(float)) return VariableTypes.Number;
        if (type == typeof(bool)) return VariableTypes.Toggle;

        return VariableTypes.Any;
    }

    public static VariableTypes GetVariableTypeFormString(string type)
    {
        if (type == "float") return VariableTypes.Number;
        if (type == "bool") return VariableTypes.Toggle;

        return VariableTypes.Any;
    }


    public static Type GetTypeFromVariableType(VariableTypes type)
    {
        if (type == VariableTypes.Number) return typeof(float);
        if (type == VariableTypes.Toggle) return typeof(bool);

        return typeof(object);
    }


    // TEMP
    [HideInInspector] public bool ToRemove;
}
