using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    [HideInInspector]
    public int score;
    public GUISkin skin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        int sw = Screen.width;
        int sh = Screen.height;
        string scoreText = "SCORE: " + score.ToString();
        //GUI.Label(new Rect (0, 0, sw / 2,  sh / 3), scoreText);
        GUI.Label(new Rect(0, 0, sw / 2, sh / 3), scoreText, "Score");
    }
}
