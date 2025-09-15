using UnityEngine;

public class GameStarter : MonoBehaviour
{
    
    public GUISkin skin;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0.0f){
            BroadcastMessage("StartGame");
            enabled = false;
        }
    }

    private void OnGUI()
    {
        if (timer > 3.0f || timer <= 0.0f)
            return;
        GUI.skin = skin;
        int sw = Screen.width;
        int sh = Screen.height;

        string text = Mathf.CeilToInt(timer).ToString();
        GUI.color = new Color(1,1,1,timer - Mathf.FloorToInt(timer));
        GUI.Label(new Rect (0, sh/4, sw, sh/2), text, "Message");
    }
}
