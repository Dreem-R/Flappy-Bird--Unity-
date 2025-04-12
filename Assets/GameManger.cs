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

        foreach (var agent in agents)
        {
            agent.EndEpisode(); // resets position & flags via OnEpisodeBegin
        }

        aliveAgents = agents.Count;
    }
}

