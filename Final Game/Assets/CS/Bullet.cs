using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;
    public float lifeTime = 1.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = transform.forward * speed; 
        }

        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            var player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                var controller = player.GetComponent<ch46PlayController>();
                if (controller != null)
                {
                    controller.ResetPlayer(); 
                }
            }

            Destroy(gameObject); 
        }
        else
        {
            Destroy(gameObject, 2f); 
        }
    }
}
