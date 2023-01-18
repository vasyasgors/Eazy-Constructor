using UnityEngine;

// To unity inspector hack
public abstract class VariableBase<T> : ScriptableObject
{
    public string Name = "Unknown";
    public T Value;

    public VariableBase()
    {
        Name = "PropertyName";
    }
}


