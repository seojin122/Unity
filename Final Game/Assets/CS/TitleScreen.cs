using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GUISkin skin;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Final Game");
        }
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        int sw = Screen.width;
        int sh = Screen.height;

        GUI.Label(new Rect(0, 0, sw, sh), "Last Shot", "Message");
        GUI.Label(new Rect(0, sh / 2, sw, sh / 2), "Click to Start", "Message2");
    }
}
