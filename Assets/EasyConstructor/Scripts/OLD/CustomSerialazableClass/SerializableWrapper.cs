using System;
using UnityEngine;


namespace PropertyOld
{
    [System.Serializable]
    public class SerializableClass
    {
    }

    [Serializable]
    public class SerializableClassWrapper : ISerializationCallbackReceiver
    {
        [SerializeField] private string serializedObject;
        [SerializeField] private string type;

        // [NonSerialized]
        private SerializableClass value;


        public SerializableClassWrapper(SerializableClass value)
        {
            serializedObject = Serialize(value);
            type = value.GetType().ToString();
        }

        public SerializableClass Value
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


            Type t = Type.GetType(type);




            return JsonUtility.FromJson(serialized, Type.GetType(type)) as SerializableClass;
        }

        public static string Serialize(SerializableClass value)
        {
            return JsonUtility.ToJson(value);
        }

        /*
        public static string Serialize(Type type)
        {
            return JsonUtility.ToJson(Activator.CreateInstance(type) as SerializableClass);
        }*/

        public void OnAfterDeserialize()
        {
            //string s = JsonUtility.FromJson(serializedObject, Type.GetType(type)) as string;

            string objectID = serializedObject.Split(',')[0];
            string[] s = objectID.Split(':');
            objectID = s[s.Length - 1];
            objectID = objectID.Split('}')[0];

            int gameObjectInstance = int.Parse(objectID);

            //GameObject.Find(objectID);


            // Debug.Log(objectID);
            //  Debug.Log(GameObject.Find(objectID));

        }

        public void OnBeforeSerialize()
        {
            //Serialize(value);
        }
    }
}