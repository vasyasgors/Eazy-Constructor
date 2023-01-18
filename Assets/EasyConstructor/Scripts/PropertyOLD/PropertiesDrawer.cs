using UnityEditor;
using UnityEngine;


namespace PropertyOld
{
    [CustomEditor(typeof(Properties))]
    public class PropertiesDrawer : Editor
    {

        private SerializedProperty serializedProperty;


        public override void OnInspectorGUI()
        {

            serializedProperty = serializedObject.FindProperty("intProperties");

            for (int i = 0; i < serializedProperty.arraySize; i++)
            {
                SerializedProperty currentActionProperty = serializedProperty.GetArrayElementAtIndex(i);


                EditorGUILayout.PropertyField(currentActionProperty);


            }
        }


    }
}

