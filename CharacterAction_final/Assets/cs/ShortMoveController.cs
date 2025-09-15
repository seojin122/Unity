using System.Collections;
using UnityEngine;

public class ShortMoveController : MonoBehaviour
{
    public float velocity = 8.0f;
    public float sustainTime = 3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if(player != null)
        {
            StartCoroutine(WaitAndStart(player, sustainTime));
        }

    }

    IEnumerator WaitAndStart(GameObject player, float time)
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        yield return new WaitForSeconds(time);
        GetComponent<Rigidbody>().AddForce(direction * velocity, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
