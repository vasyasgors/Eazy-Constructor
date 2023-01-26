using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace PropertyOld
{


    public class Properties : MonoBehaviour
    {
        public PInt[] intProperties;
        public PFloat[] floatProperties;
        public PVector2[] vector2Properties;
        /*
        public void TryLinkProperty(ref Int property)
        {
            for(int i = 0; i < inte.Length; i++)
            {
                if (inte[i].Name == property.Name)
                {
                    property = inte[i];
                    return;
                }    
            }
        }
        */
    }
}

