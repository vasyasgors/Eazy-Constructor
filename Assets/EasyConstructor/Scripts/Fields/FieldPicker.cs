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
    [SerializeField] protected T value;

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

[Serializable] public class TransformPicker : FieldPickerGeneric<Transform> 
{
    public static implicit operator Transform(TransformPicker picker)
    {
        return picker.value;
    }


    public static implicit operator TransformPicker(Transform transform)
    {
        return new TransformPicker() { value = transform };
    }


}
[Serializable] public class MaterialPicker : FieldPickerGeneric<Material> { }

// ТАк можно попробовать избавиться от Value, но нужно ли?
[Serializable] public class IntPicker : FieldPickerGeneric<int> 
{

    public static implicit operator int(IntPicker picker)
    {
        return picker.value;
    }

    public static implicit operator IntPicker(int intValue)
    {
        return new IntPicker() { value = intValue };
    }


}


