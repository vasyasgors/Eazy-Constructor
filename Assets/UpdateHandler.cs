using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpdateHandler : MonoBehaviour {


	public UnityEvent Spawn;
	public UnityEvent EveryFrame;
	public UnityEvent Destory;

	
	void Start () 
	{
		if (Spawn != null)
			Spawn.Invoke();
	}
	
	
	void Update ()
	{
		if (EveryFrame != null)
			EveryFrame.Invoke();
	}

	void OnDestory()
    {
		if (Destory != null)
			Destory.Invoke();
	}
}
