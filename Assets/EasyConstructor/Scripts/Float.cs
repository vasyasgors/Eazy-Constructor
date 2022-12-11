using UnityEngine;

[CreateAssetMenu]
public class Float : ScriptableObject
{
    [SerializeField]
    public float Value;

    public float Value1 { get { return Value; } }

    public void Add(float value)
    {
        Value += value;
    }

    public void Remove(float value)
    {
        Value -= value;
    }

    public void Set(float value)
    {
        Value = value;
    }
}
