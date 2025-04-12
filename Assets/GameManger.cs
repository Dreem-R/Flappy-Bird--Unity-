using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public List<Go_Between_Pipe> agents;
    public PipeSpawn pipeSpawner;

    private int aliveAgents;

    void Start()
    {
        aliveAgents = agents.Count;
    }

    public void AgentDied()
    {
        aliveAgents--;

        if (aliveAgents <= 0)
        {
            ResetEnvironment();
        }
    }

    void ResetEnvironment()
    {
        pipeSpawner.ResetPipes();
        aliveAgents = agents.Count;

        foreach (var agent in agents)
        {
            agent.EndEpisode();  // OnEpisodeBegin will be called next
        }
    }
}

