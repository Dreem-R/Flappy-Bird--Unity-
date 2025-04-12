using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class Go_Between_Pipe : Agent
{
    public LogicScript LogicScript;
    public Birdscript Birdscript;
    public RayPerceptionSensorComponent3D raySensor;
    public Vector3 startPosition;
    public GameManger gameManager;

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (!Birdscript.isBirdAlive)
        {
            return;
        }

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

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;  // Clear linear velocity
        rb.angularVelocity = 0f;     // Clear angular velocity
        transform.rotation = Quaternion.identity;  // Reset rotation to default

        Birdscript.isBirdAlive = true;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Birdscript.isBirdAlive && other.CompareTag("Score"))
        {
            AddReward(0.5f);  // reward for crossing pipe
            Debug.Log("Passed pipe!");
        }
    }

    public void death()
    {
        Debug.Log("Bird Died At Go_between_Pipe Death()");
        AddReward(-1.0f);
        gameManager.AgentDied();  // triggers centralized check
    }


    public void reward(float delta)
    {
        AddReward((float)delta);
    }
}
