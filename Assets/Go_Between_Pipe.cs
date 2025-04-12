using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;

public class Go_Between_Pipe : Agent
{
    public override void OnActionReceived(ActionBuffers actions)
    {
        Debug.Log("OnActionReceived called");
        Debug.Log("Discrete Action: " + actions.DiscreteActions[0]);
    }

    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("Agent Initialized");
    }

    void Start()
    {
        Debug.Log("Agent Start");
    }
}
