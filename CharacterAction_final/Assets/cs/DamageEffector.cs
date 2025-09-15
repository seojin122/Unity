using System.Collections;
using UnityEngine;

public class DamageEffector : MonoBehaviour
{
    private bool effectFlag;
    private Color originalColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
        effectFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (effectFlag)
        {
            GetComponent<Renderer>().material.color = Color.red * Mathf.Abs(Mathf.Sin(40.0f * Time.time));
        }
    }

    IEnumerator Wait(float time)
    {
        effectFlag = true;
        yield return new WaitForSeconds(time);
        effectFlag = false;
        GetComponent<Renderer>().material.color = originalColor;
    }
    void ApplyDamage(int amount)
    {
        StartCoroutine(Wait(0.3f));
    }
}
