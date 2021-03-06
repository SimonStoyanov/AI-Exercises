﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GOAP;

public class GOAP_Action_Patrol : Action
{
    GOAP_Agent entity;
    Transform target;

    // Constructor
    public GOAP_Action_Patrol()
    {
        AddPrecondition("CloseTo", null);
        AddEffect("Patrolling", true);
        cost = 1;
    }
    //Called by the planner when the action is being considered. This function is used to receive the iGoap and current state
    //variables.
    public override void OnActionSetup(IGoap iGoap, List<Condition> state)
    {
        entity = (GOAP_Agent)iGoap;
        target = entity.PatrolPoint;
        UpdatePrecondition("CloseTo", target);
        isViable = (target != null);
    }

    // Called by the GoapUpdater, this function is called when this action is in the current plan and started.
    public override void OnActionStart()
    {
        entity.path.SetActive(true);
    }

    // Called by the GoapUpdater, this function will be called until the action is either finished, or aborted
    public override void OnActionPerform()
    {
        if (entity.GetComponent<AIPerceptionManager>().player_detected)
            isFinished = true;
    }
    // Called by the GoapUpdater, this function will be called when this action is finished.
    public override void OnActionFinished()
    {
        entity.path.SetActive(false);
    }
    // Called by the GoapUpdater, this function will be called when this action is aborted.
    public override void OnActionAborted() { }
}