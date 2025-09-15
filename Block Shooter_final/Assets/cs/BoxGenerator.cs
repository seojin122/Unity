using System;
using UnityEngine;

public class BoxGenerator : MonoBehaviour
{
    public float interval;
    public GameObject redBoxPrefab;
    public GameObject blueBoxPrefab;

    private Boolean nextIsRed;
    private float timer;

    private void TimeUp()
    {
        enabled = false;
    }
    private void StartGame()
    {
    enabled = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextIsRed = true;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
 
        timer -= Time.deltaTime;
        if(timer < 0.0f)
        {

            float offsx = UnityEngine.Random.Range(-8.0f, 8.0f);
            float offsz = UnityEngine.Random.Range(-4.0f, 4.0f);
            Vector3 position = transform.position + new Vector3(offsx, 0.0f, offsz);
            
            GameObject prefab = nextIsRed ? redBoxPrefab : blueBoxPrefab;
            Instantiate(prefab, position, UnityEngine.Random.rotation);

            timer = interval;
            nextIsRed = !nextIsRed;
        }


    }
}
