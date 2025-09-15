using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{ 
    public GUISkin skin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("Main");
        }
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        int sw = Screen.width;
        int sh = Screen.height;
        GUI.Label(new Rect (0, 0, sw, sh), "B L O C K S H O O T E R", "Message");
        GUI.Label(new Rect (0, sh/2, sw, sh/2), "Click to Start", "Message");
    }
}
