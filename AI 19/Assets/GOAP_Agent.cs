using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GOAP;
public class GOAP_Agent : MonoBehaviour, IGoap
{
    public List<Condition> state { get; set; }
    public List<Goal> availableGoals { get; set; }
    public List<Action> availableActions { get; set; }

    public Transform Alarm;
    public Transform PatrolPoint;
    public GameObject path;

    // Use this for initialization
    private void Awake()
    {
        state = new List<Condition>();
        availableGoals = new List<Goal>();
        availableActions = new List<Action>();

        availableGoals.Add(ScriptableObject.CreateInstance<GOAP_Goal_SearchForPlayer>());
        availableGoals.Add(ScriptableObject.CreateInstance<GOAP_Goal_SoundAlarm>());
        availableActions.Add(ScriptableObject.CreateInstance<GOAP_Action_GoTo>());
        availableActions.Add(ScriptableObject.CreateInstance<GOAP_Action_Patrol>());
        availableActions.Add(ScriptableObject.CreateInstance<GOAP_Action_SoundAlarm>());

        foreach (Goal g in availableGoals)
            g.OnGoalInitialize(this);
    }
}