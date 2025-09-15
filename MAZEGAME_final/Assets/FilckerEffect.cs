using UnityEngine;

public class FilckerEffect : MonoBehaviour
{
    private Color originalColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        float level = Mathf.Abs(Mathf.Sin(20.0f * Time.time));
        GetComponent<Renderer>().material.color = originalColor * level;
    }
}
