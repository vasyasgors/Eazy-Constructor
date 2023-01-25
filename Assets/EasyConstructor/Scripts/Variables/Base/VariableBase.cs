using UnityEngine;

// To unity inspector hack
[System.Serializable]
public abstract class Variable
{
    public string Name;
    

}

public abstract class VariableBase<T> : Variable
{
     public T Value;
}

[System.Serializable]
public class IntVariable : VariableBase<int>
{

}





