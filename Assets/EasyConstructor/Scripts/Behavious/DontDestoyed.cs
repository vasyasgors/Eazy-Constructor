﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoyed : MonoBehaviour 
{
	private void Awake()
    {
        DontDestroyOnLoad(this);
    }
	
}
