using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GUIStyle labelStyle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("MAze Game");
        }
    }

    private void OnGUI()
    {
        int sw = Screen.width;
        int sh = Screen.height;
        GUI.Label(new Rect(0, sh / 4, sw , sh / 4), "BALL MAZE", labelStyle);
        GUI.Label(new Rect(0, sh / 2, sw, sh / 4), "Hit Space Bar", labelStyle);

    }

}
