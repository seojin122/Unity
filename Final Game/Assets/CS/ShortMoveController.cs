using System.Collections;
using UnityEngine;

public class ShortMoveController : MonoBehaviour
{
    public float velocity = 8.0f;
    public float moveDelay = 1.0f;
    public float sustainTime = 3.0f;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null && TryGetComponent<Rigidbody>(out var rb))
        {
            StartCoroutine(WaitAndStart(rb, player.transform.position, sustainTime));
        }
    }

    IEnumerator WaitAndStart(Rigidbody rb, Vector3 targetPosition, float time)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        yield return new WaitForSeconds(time);
        rb.AddForce(direction * velocity, ForceMode.VelocityChange);
    }

    void Update()
    {
    }
}
