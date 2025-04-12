using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;

public class Go_Between_Pipe : Agent
{
    public LogicScript LogicScript;
    public Birdscript Birdscript;

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
