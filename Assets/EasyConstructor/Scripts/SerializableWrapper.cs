using System;
using UnityEngine;

/*
[Serializable]
public class SerializableWrapper<T> where T: class
{
    [SerializeField] public string serializedObject;
    [SerializeField] public string type;

    [NonSerialized] private T value;

    public SerializableWrapper(T value)
    {
        serializedObject = Serialize(value);
        type = value.GetType().ToString();
    }

    public T Value
    {
        get
        {
            if (value == null)
                return Deserialize(serializedObject, type);
            else
                return value;
        }
    }
  

    public static T Deserialize(string serialized, string type)
    {
        return JsonUtility.FromJson(serialized, Type.GetType(type)) as T;
    }

    public static string Serialize(T value)
    {
        return JsonUtility.ToJson(value);
    }
}
*/