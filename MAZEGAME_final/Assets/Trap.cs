using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameObject respawn = GameObject.FindWithTag("Respawn");
            other.gameObject.transform.position = respawn.transform.position;
        }
    }
}


