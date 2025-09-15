using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private int ballCount;
    private int counter;
    private Boolean cleared;
    public GUIStyle labelStyle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cleared = false;
        ballCount = GameObject.FindGameObjectsWithTag("Ball").Length;
        Debug.Log("Start!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelayedLoadScrene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Title");
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            counter++;

            if(cleared == false && counter == ballCount)
            {
                cleared = true;
                StartCoroutine(DelayedLoadScrene(2.0f));
            }
        }

    }

    private void OmTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
            counter--;
    }

    private void OnGUI()
    {
        if(cleared == true)
        {
            int sw = Screen.width;
            int sh = Screen.height;
            GUI.Label(new Rect(sw / 6, sh / 3, sw * 2 / 3, sh * 2 / 3), "CLEARED!!", labelStyle);
        }
    }
}
