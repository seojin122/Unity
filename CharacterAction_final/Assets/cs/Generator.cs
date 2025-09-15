using System.Collections;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float intervalMin = 0.5f;
    public float intervalMax = 1.5f;
    public float coinRate = 0.3f;
    public GameObject coinPrefab;
    public GameObject spikeBallPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(intervalMin, intervalMax));
            GameObject prefab = Random.value < coinRate ? coinPrefab : spikeBallPrefab;
            float theta = Random.Range(0.0f, Mathf.PI * 2.0f);
            Vector3 position = new Vector3(Mathf.Cos(theta), 0.0f, Mathf.Sin(theta)) * 5.5f;
            position.y = 2.5f;
            Instantiate(prefab, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}








