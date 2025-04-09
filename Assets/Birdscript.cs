using Unity.VisualScripting;
using UnityEngine;

public class Birdscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D myRigidbody2D;
    public float flapspeed;
    public LogicScript LogicScript;
    public bool isBirdAlive = true;

    void Start()
    {
        LogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && isBirdAlive)
        {
            myRigidbody2D.linearVelocity = Vector2.up * flapspeed;
        }

        else if (Input.GetKeyDown(KeyCode.Escape)){
            LogicScript.pause();
        }

        if(myRigidbody2D.transform.position.y > 4.4 || myRigidbody2D.transform.position.y < -5)
        {
            isBirdAlive=false;
            LogicScript.gameoverscreen();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LogicScript.gameoverscreen();
        isBirdAlive = false;
    }
}
