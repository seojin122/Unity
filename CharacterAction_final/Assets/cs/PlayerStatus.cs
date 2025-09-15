using System.Collections;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private int life = 100;
    private int score = 0;
    public GameObject coinParticlePrefab;
    public GameObject damageParticlePrefab;
    public GUISkin skin;

    private GUIStyle scoreStyle;
    private bool effectFlag;
    private Color originalScoresColor;


    void CatchCoin(int amount)
    {
        Instantiate(coinParticlePrefab, transform.position, transform.rotation);
        score += amount;
    }

    IEnumerator Wait(float time)
    {
        effectFlag = true;
        yield return new WaitForSeconds(time);
        effectFlag = false;
        scoreStyle.normal.textColor = originalScoresColor;
    }

    void ApplyDamage(int amount)
    {
        StartCoroutine(Wait(0.3f));
        life -= amount;
        if (life < 0)
        {
            Instantiate(damageParticlePrefab, transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        Rect rect1 = new Rect(0, 0, Screen.width, Screen.height);
        Rect rect2 = new Rect(Screen.width/2, 0, Screen.width, Screen.height);
        GUI.Label(rect1, "LIFE: " + life.ToString(), "Life");
        GUI.Label(rect2, "SCORE: " + score.ToString(), "Score");
        //Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        //GUI.Label(rect, "LIFE: " + life.ToString() + "/ SCORE: " + score.ToString());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreStyle = skin.GetStyle("Life");
        originalScoresColor = scoreStyle.normal.textColor;
        effectFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (effectFlag)
            scoreStyle.normal.textColor = Color.red * Mathf.Abs(Mathf.Sin(40.0f * Time.time));
    }
}
