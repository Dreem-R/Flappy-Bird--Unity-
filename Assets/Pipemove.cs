using UnityEngine;

public class Pipemove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float movespeed = 5;
    public float deadpoint = -10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * movespeed) * Time.deltaTime;
        if (transform.position.x < deadpoint)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
