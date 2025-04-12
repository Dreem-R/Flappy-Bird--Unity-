using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class Go_Between_Pipe : Agent
{
    public LogicScript LogicScript;
    public Birdscript Birdscript;
    public RayPerceptionSensorComponent3D raySensor;

    public override void OnActionReceived(ActionBuffers actions)
    {
        AddReward(0.1f);
        int action = actions.DiscreteActions[0];

        if (action == 1)
        {
            Birdscript.jump();
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("Agent Initialized");
        raySensor = GetComponentInChildren<RayPerceptionSensorComponent3D>();
    }

    public override void OnEpisodeBegin()
    {
        LogicScript.restartgame();
    }

    public void death()
    {
        AddReward(-1.0f);
        EndEpisode();
    }

    public void reward(float delta)
    {
        AddReward((float)delta);
    }
}
