using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using GOAP;

public class GOAP_Action_GoTo : Action
{
    GOAP_Agent entity;
    Transform target;
    NavMeshAgent agent;

    // Constructor
    public GOAP_Action_GoTo()
    {
        AddEffect("CloseTo", null);
        cost = 1;
    }
    //Called by the planner when the action is being considered. This function is used to receive the iGoap and current state
    //variables.
    public override void OnActionSetup(IGoap iGoap, List<Condition> state)
    {
        entity = (GOAP_Agent)iGoap;
        target = null;

        foreach (Condition c in state)
        {
            if (c.identifier == "CloseTo")
            {
                target = (Transform)c.value;
                break;
            }
        }

        UpdateEffect("CloseTo", target);
        isViable = (target != null);
    }

    // Called by the GoapUpdater, this function is called when this action is in the current plan and started.
    public override void OnActionStart()
    {
        agent = entity.GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    // Called by the GoapUpdater, this function will be called until the action is either finished, or aborted
    public override void OnActionPerform()
    {
        if (agent.remainingDistance <= 0.1f)
        {
            isFinished = true;
        }
    }

    // Called by the GoapUpdater, this function will be called when this action is finished.
    public override void OnActionFinished() { }
    // Called by the GoapUpdater, this function will be called when this action is aborted.
    public override void OnActionAborted() { }
}