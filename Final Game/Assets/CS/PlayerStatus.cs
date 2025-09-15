using System.Collections;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private int life = 100;
    private int score = 0;
    public GameObject coinParticlaPrefab;
    public GameObject damageParticlePrefab;
    public GUISkin skin;

    private GUIStyle scoreStyle;
    private bool effectFlag;
    private Color originalScoreColor;

    void CatchCoin(int amount)
    {
        if (coinParticlaPrefab != null)
        {
            Instantiate(coinParticlaPrefab, transform.position, transform.rotation);
        }

        score += amount;
    }

    IEnumerator Wait(float time)
    {
        effectFlag = true;
        yield return new WaitForSeconds(time);
        effectFlag = false;

        if (scoreStyle != null)
        {
            scoreStyle.normal.textColor = originalScoreColor;
        }
    }

    public void ApplyDamage(int amount)
    {
        Debug.Log("✅ ApplyDamage 호출됨, amount: " + amount);
        StartCoroutine(Wait(0.3f));
        life -= amount;

        if (life < 0)
        {
            if (damageParticlePrefab != null)
            {
                Instantiate(damageParticlePrefab, transform.position, transform.rotation);
            }

            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }

    private void OnGUI()
    {
        if (skin != null)
        {
            GUI.skin = skin;

            Rect rect1 = new Rect(0, 0, Screen.width, Screen.height);
            Rect rect2 = new Rect(Screen.width / 2, 0, Screen.width, Screen.height);

            GUI.Label(rect1, "LIFE : " + life.ToString(), "Life");
            GUI.Label(rect2, "SCORE : " + score.ToString(), "Score");
        }
    }

    void Start()
    {
        if (skin != null)
        {
            scoreStyle = skin.GetStyle("Life");
            originalScoreColor = scoreStyle.normal.textColor;
        }

        effectFlag = false;
    }

    void Update()
    {
        if (effectFlag && scoreStyle != null)
        {
            scoreStyle.normal.textColor = Color.red * Mathf.Abs(Mathf.Sin(40.0f * Time.time));
        }
    }
}
