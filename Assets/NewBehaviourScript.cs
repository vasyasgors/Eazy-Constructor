using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	public NumberVariableContainer var;

	void Start()
    {
        Debug.Log(var.Variable.floatValue);
    }
}
