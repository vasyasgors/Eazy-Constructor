using System;
using UnityEngine;
using Object = UnityEngine.Object;

public enum VariableTypes
{
    Number,
    Toggle,
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
    [SerializeField] private Transform transformValue;


    public object Value
    {
        get
        {
            if (type == VariableTypes.Number) return floatValue;
            if (type == VariableTypes.Toggle) return boolValue;
            if (type == VariableTypes.Transform) return transformValue;

            return null;
        }

        set
        {
            if (type == VariableTypes.Number) floatValue = (float)value;
            if (type == VariableTypes.Toggle) boolValue = (bool)value;
            if (type == VariableTypes.Transform) transformValue = (Transform) value;
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
        if (type.IsSubclassOf(typeof(Transform)) == true) return VariableTypes.Transform;

        return VariableTypes.Any;
    }

    public static VariableTypes GetVariableTypeFormString(string type)
    {
        if (type == "float") return VariableTypes.Number;
        if (type == "bool") return VariableTypes.Toggle;
        if (type == "PPtr<$Transform>") return VariableTypes.Transform;

        return VariableTypes.Any;
    }


    public static Type GetTypeFromVariableType(VariableTypes type)
    {
        if (type == VariableTypes.Number) return typeof(float);
        if (type == VariableTypes.Toggle) return typeof(bool);
        if (type == VariableTypes.Transform) return typeof(Transform);

        return typeof(object);
    }


    // TEMP
    [HideInInspector] public bool ToRemove;
}
