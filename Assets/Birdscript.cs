using Unity.VisualScripting;
using UnityEngine;

public class Birdscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D myRigidbody2D;
    public float flapspeed;
    public LogicScript LogicScript;
    public bool isBirdAlive = true;
    Sound_Manager soundManager;
    public Go_Between_Pipe Go_Between_Pipe;

    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Soundfx").GetComponent<Sound_Manager>();
        LogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        if (Go_Between_Pipe == null)
        {
            Go_Between_Pipe = GetComponent<Go_Between_Pipe>();
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            jump();
        }

        else if (Input.GetKeyDown(KeyCode.Escape)){
            LogicScript.pause();
        }

        if((myRigidbody2D.transform.position.y > 4.4 || myRigidbody2D.transform.position.y < -5 ) && isBirdAlive==true)
        {
            isBirdAlive=false;
            Go_Between_Pipe.death();
        }
        
    }
    public void jump()
    {
        if (isBirdAlive == true)
        {
            myRigidbody2D.linearVelocity = Vector2.up * flapspeed;
            soundManager.PlaySFX(soundManager.flap);
        }
    }
    public bool getbird()
    {
        return isBirdAlive;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBirdAlive == true)
        {
            soundManager.PlaySFX(soundManager.death);
            isBirdAlive = false;
            Go_Between_Pipe.death();
        }
    }
}
