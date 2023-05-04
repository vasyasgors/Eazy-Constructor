using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("Timer/TimerActions")]
public class TimerActions : ActionBase
{
	private enum TimerAction
    {
		Stop,
		Pause,
		Restart,
	}

    [SerializeField] private Timer timer;
    [SerializeField] private TimerAction timerAction;

	public override void StartExecute()
	{
		if (timerAction == TimerAction.Pause) timer.Pause();
		if (timerAction == TimerAction.Restart) timer.Restart();
		if (timerAction == TimerAction.Stop) timer.Stop();
	}
}


