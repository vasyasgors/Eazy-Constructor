using System;
using UnityEngine;


[Serializable]
public abstract class SerializableClass
{
}

[Serializable]
public class SerializableClassWrapper
{
    [SerializeField] private string serializedObject;
    [SerializeField] private string type;

    [NonSerialized] private SerializableClass value;

    
    public SerializableClassWrapper(SerializableClass value)
    {
        serializedObject = Serialize(value);
        type = value.GetType().ToString();
    }

    public  SerializableClass Value
    {
        get
        {
            if (value == null)
                return Deserialize(serializedObject, type);
            else
                return value;
        }
    }
  
    public static SerializableClass Deserialize(string serialized, string type)
    {
        return JsonUtility.FromJson(serialized, Type.GetType(type)) as SerializableClass;
    }

    public static string Serialize(SerializableClass value)
    {
        return JsonUtility.ToJson(value);
    }


    public static string Serialize(Type type)
    {
        return JsonUtility.ToJson(Activator.CreateInstance(type) as SerializableClass);
    }

}
