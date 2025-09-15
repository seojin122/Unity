using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Scorekeeper))]

public class ResultScreen : MonoBehaviour
{
    public GUISkin skin;
    private Scorekeeper scorekeeper;
    private string state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scorekeeper = GetComponent<Scorekeeper>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TimeUpSeseion()
    {
        state = "Time Up";
        yield return new WaitForSeconds(3.0f);
        state = "";
        yield return new WaitForSeconds(5.0f);
        state = "Show Score";
        while (!Input.GetButtonDown("Fire1"))
            yield return null;
        SceneManager.LoadScene("Title");
    }

    private void TimeUp()
    {
        StartCoroutine(TimeUpSeseion());
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        int sw = Screen.width;
        int sh = Screen.height;
        if(state == "Time Up")
        {
            GUI.Label(new Rect(0, 0, sw, sh), "Time Up!!", "Message");
        }else if (state == "Show Score")
        {
            string scoreText = "your Score is " + scorekeeper.score.ToString();
            GUI.Label(new Rect(0, sh / 4, sw, sh / 4), scoreText, "Message");
            GUI.Label(new Rect(0, sh/2, sw, sh / 4),"Click to Exit", "Message");
        }
    }




}
