using System;
using UnityEngine;


[Serializable] 
public abstract class FieldPicker
{
    public enum FieldPikerState
    {
        Value,
        Variable
    }

    [SerializeField] protected VariablePicker variablePicker;
    [SerializeField] protected FieldPikerState state;
}

[Serializable]
public abstract class FieldPickerGeneric<T> : FieldPicker
{
    [SerializeField] private T value;

    public T Value
    {
        get
        {
            if (state == FieldPikerState.Variable)
            {
                return (T) variablePicker.Variable.Value;
            }

            return value;
        }

        set
        {
            if (state == FieldPikerState.Variable)
            {
                variablePicker.Variable.Value = value;
            }

            this.value = value;
        }
    }
}

// Hack for unity inspector
[Serializable] public class FloatPicker : FieldPickerGeneric<float> { }
[Serializable] public class BoolPicker : FieldPickerGeneric<bool> { }
[Serializable] public class TransformPicker : FieldPickerGeneric<Transform> { }


