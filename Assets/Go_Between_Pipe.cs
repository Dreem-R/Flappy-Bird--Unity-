using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class Go_Between_Pipe : Agent
{
    public LogicScript LogicScript;
    public Birdscript Birdscript;
    public RayPerceptionSensorComponent3D raySensor;
    public bool isbirdalive;
    public Vector3 startPosition;
    public GameManger gameManager;

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
        startPosition = transform.position;
        Birdscript = GetComponent<Birdscript>();
        gameManager = GameObject.FindGameObjectWithTag("Ml_Manager").GetComponent<GameManger>();
        raySensor = GetComponentInChildren<RayPerceptionSensorComponent3D>();
    }

    public override void OnEpisodeBegin()
    {
        transform.position = startPosition;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0f;
        GetComponent<Rigidbody2D>().transform.rotation = Quaternion.identity; 
        isbirdalive = true;
        Birdscript.isBirdAlive = true;
    }

    public void death()
    {
        AddReward(-1.0f);
        gameManager.AgentDied();
        EndEpisode();
    }

    public void reward(float delta)
    {
        AddReward((float)delta);
    }
}
