using System;
using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;

public class Box : MonoBehaviour
{
    public string colorName;
    public GameObject explosionPrefab;

    private Boolean hit;
    private float killTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hit)
            return;
        killTimer -= Time.deltaTime;
        if(killTimer <= 0.0f)
        {
            GameObject gameController = GameObject.FindWithTag("GameController");

            gameController.SendMessage("OnDestroyBox", colorName);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void YouAreHit()
    {
        //Instantiate(explosionPrefab, transform.position, transform.rotation);
        //Destroy(gameObject);
        if (!hit)
        {
            hit = true;
            killTimer = 0.4f;
            GetComponent<Rigidbody>().AddForce(Vector3.up * 35.0f, ForceMode.Impulse);
        }
    }
}
