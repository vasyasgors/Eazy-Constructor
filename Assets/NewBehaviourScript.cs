﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	public ActionWrapper[] actions;



    void Start()
    {
        actions[0].GetAction().StartExecute();
     //   actions[1].Action.StartExecute();
    }

    [ContextMenu("Add")]
    public void Add()
    {
        actions = new ActionWrapper[2];

        actions[0] = new ActionWrapper();
        actions[0].serialazableString = ActionWrapper.SerializeAction( new FirstAction());
        actions[0].type = "FirstAction";


        actions[1] = new ActionWrapper();
        actions[1].serialazableString = ActionWrapper.SerializeAction(new SecondAction());
        actions[1].type = "SecondAction";

        /*
        actions[0] = new ActionWrapper();
        actions[0].Action = new FirstAction();
        actions[0].type = "FirstAction";

        actions[1] = new ActionWrapper();
        actions[1].Action = new SecondAction();
        actions[1].type = "SecondAction";
        */
    }


    /*
    void Start()
    {
        Debug.Log("Start " + actions.Action.GetType());
    }

    [ContextMenu("TestMoveAction")]
	public void Add()
    {
        actions.Action = new TestMoveAction();
        actions.type = "TestMoveAction";
    }

    [ContextMenu("TestAnyAction")]
    public void Add2()
    {
        actions.Action = new TestAnyAction();
        actions.type = "TestAnyAction";
    }
    */
}
