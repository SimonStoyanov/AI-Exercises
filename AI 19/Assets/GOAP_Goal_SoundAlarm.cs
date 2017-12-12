using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GOAP;

public class GOAP_Goal_SoundAlarm : Goal
{
    GOAP_Agent entity;

    // Constructor
    public GOAP_Goal_SoundAlarm()
    {
        AddSucces("AlarmTriggered", true);
        priority = 5;
    }

    // Should be called from the iGoap class. This initializes the goal class.
    // The reason a goal has a initialize function, and the actions don't is because action are
    // copied by the planner, while a goal remains the same throughout.
    public override void OnGoalInitialize(IGoap igoap)
    {
        this.igoap = igoap;
        entity = (GOAP_Agent)igoap;
    }
    // Called from the planner. Useful to change values on runtime
    public override void OnGoalSetup() { }
    // Called by the goapUpdater, this will be called when the plan was successful and the goal is finished.
    public override void OnGoalFinished() { }
    // Called from the goapUpdater, this will be called when one of the actions, and thus the plan, was aborted.
    public override void OnGoalAborted() {}
    // Called from the planner, the returned value is used to see if the goal can be used by the planner.
    // This is called after OnGoalSetup. This function is marked abstract, and thus is required to always be implemented.
    public override bool IsGoalRelevant()
    {
        if (entity.GetComponent<AIPerceptionManager>().player_detected)
            return true;
        return false;
    }
}
