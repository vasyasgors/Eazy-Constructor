using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ScriptableVariable : ScriptableObject
{
    public Variable Variable;

    public static Variable[] GetAllInstances() 
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(ScriptableVariable).Name);  //FindAssets uses tags check documentation for more info
        Variable[] variables = new Variable[guids.Length];

        for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            variables[i] = AssetDatabase.LoadAssetAtPath<ScriptableVariable>(path).Variable;

            Debug.Log(AssetDatabase.LoadAssetAtPath<ScriptableVariable>(path).Variable);
        }

        return variables;

    }
}
