using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Constructor/Timer")]
public class Timer : MonoBehaviour
{
	[SerializeField] private FloatPicker time;
	[SerializeField] private FloatPicker repetitionCount;
	[SerializeField] private EventHandler complete;
	//[SerializeField] [VariablePickerType(VariableTypes.Number)]  private VariablePicker variable;


	private float elapsedTime = 0;
	private float completeCount = 0;
	private bool _enabled;

	void Start()
    {
		elapsedTime = 0;
		_enabled = true;
	}

	void OnEnabled()
    {
		elapsedTime = 0;
		_enabled = true;
	}


	void Update()
    {
		if (_enabled == false) return;

		if (repetitionCount.Value == 0) return;

		elapsedTime += Time.deltaTime;

		//if (variable.Variable != null)
		//	variable.Variable.Value = elapsedTime;

		if (elapsedTime >= time.Value)
        {
			complete.ForceInvoke(gameObject, gameObject);

			completeCount++;

			if (completeCount < repetitionCount.Value || repetitionCount.Value < 0)
			{
				elapsedTime = 0;
			}
			else
            {
				_enabled = false;
			}
        }
	}

	public void Restart()
    {
		elapsedTime = 0;
		_enabled = true;
    }

	public void Pause()
	{
		_enabled = !_enabled;
	}

	public void Stop()
    {
		elapsedTime = 0;
		_enabled = false;
	}

	public float GetElapsedTime()
    {
		return elapsedTime;
    }



	
}
