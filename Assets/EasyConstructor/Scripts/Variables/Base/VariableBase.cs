using UnityEngine;

// To unity inspector hack
public abstract class Variable : ScriptableObject
{
}

public abstract class VariableBase<T> : Variable
{
     public T Value;
}


