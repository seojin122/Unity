using System.Collections;
using UnityEngine;

public class DamageEffector : MonoBehaviour
{
    private bool effectFlag;
    private Color originalColor;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            originalColor = rend.material.color;
        }

        effectFlag = false;
    }

    void Update()
    {
        if (effectFlag && rend != null)
        {
            rend.material.color = Color.red * Mathf.Abs(Mathf.Sin(40.0f * Time.time));
        }
    }

    IEnumerator Wait(float time)
    {
        effectFlag = true;
        yield return new WaitForSeconds(time);
        effectFlag = false;

        if (rend != null)
        {
            rend.material.color = originalColor;
        }
    }

    void ApplyDamage(int amount)
    {
        StartCoroutine(Wait(0.3f));
    }
}
