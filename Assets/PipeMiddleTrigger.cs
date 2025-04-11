using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public LogicScript LogicScript;
    public Birdscript birdobj;

    void Start()
    {
        LogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdobj = GameObject.FindGameObjectWithTag("Player").GetComponent<Birdscript>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bird") && birdobj.getbird())
        {
            LogicScript.addscore(1);
        }
    }
}
