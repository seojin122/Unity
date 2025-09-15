using System.Collections;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float intervalMin = 1.0f;
    public float intervalMax = 1.5f;

    public GameObject coinPrefab;
    public GameObject spikeBallPrefab;

    private int coinCount = 0;
    private int spikeBallCount = 0;

    private Vector3 center = new Vector3(-88.6f, 3.27f, 20.7f);

    void Start()
    {
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        while (coinCount < 2 && spikeBallCount < 5)
        {
            yield return new WaitForSeconds(Random.Range(intervalMin, intervalMax));

            float theta = Random.Range(0f, Mathf.PI * 2f);
            Vector3 offset = new Vector3(Mathf.Cos(theta) * 5.5f, 0f, Mathf.Sin(theta) * 5.5f);
            Vector3 position = center + offset;

            if (coinCount < 2 && coinPrefab != null)
            {
                Instantiate(coinPrefab, position, Quaternion.identity);
                coinCount++;
            }

            if (spikeBallCount < 5 && spikeBallPrefab != null)
            {
                Instantiate(spikeBallPrefab, position, Quaternion.identity);
                spikeBallCount++;
            }
        }
    }
}
