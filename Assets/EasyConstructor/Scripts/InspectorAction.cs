using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InspectorAction : MonoBehaviour
{


    public Condition condition;
   
    public List<ActionBase> actions;


    public void AddAction()
    {
        if (actions == null) actions = new List<ActionBase>();

        if (UnityEngine.Random.Range(0, 2) == 0)
        {
           // actions.Add(gameObject.AddComponent<DestoryAction>());
           // actions[actions.Count - 1].hideFlags = HideFlags.HideInInspector;
        }
        else
        {
           // actions.Add(gameObject.AddComponent<SpawnAction>());
           //actions[actions.Count - 1].hideFlags = HideFlags.HideInInspector;
        }

        }


        /*
        private Component[] arryCom;

        public void Hide()
        {
            arryCom = GetComponents(typeof(Component));
            for (int i = 0; i < arryCom.Length; i++)
            {
                Debug.Log(arryCom[i].GetType().ToString());

                if (arryCom[i].GetType().ToString() == "UnityEngine.Light")
                    arryCom[i].hideFlags = HideFlags.HideInInspector;
            }
        }

        public void Show()
        {
            arryCom = GetComponents(typeof(Component));
            for (int i = 0; i < arryCom.Length; i++)
            {
                Debug.Log(arryCom[i].GetType().ToString());

                if (arryCom[i].GetType().ToString() == "UnityEngine.Light")
                    arryCom[i].hideFlags = HideFlags.None;
            }
        }
        */
    }

