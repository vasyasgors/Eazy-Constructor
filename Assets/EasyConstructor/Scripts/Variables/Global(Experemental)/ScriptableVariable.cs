﻿#if UNITY_EDITOR
    using UnityEditor;
#endif

using UnityEngine;


public class ScriptableVariable : ScriptableObject
{
    public Variable Variable;



#if UNITY_EDITOR

    public static ScriptableVariable[] GetAllInstances() 
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(ScriptableVariable).Name);  //FindAssets uses tags check documentation for more info

        ScriptableVariable[] variables = new ScriptableVariable[guids.Length];

        for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);

            variables[i] = AssetDatabase.LoadAssetAtPath<ScriptableVariable>(path);
        }

        return variables;

    }

#endif
}
