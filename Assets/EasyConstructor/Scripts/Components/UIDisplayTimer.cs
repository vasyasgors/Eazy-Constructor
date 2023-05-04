using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Constructor/UIDisplayTimer")]
public class UIDisplayTimer : MonoBehaviour
{
	[SerializeField] private Timer timer;
	[SerializeField] private Text text;
	[SerializeField] private string format;

	void Update ()
	{
		text.text = timer.GetElapsedTime().ToString(format);
	}
}
