using UnityEngine;

[RequireComponent(typeof(Scorekeeper))]

public class Referee : MonoBehaviour
{
    public float switchInterval;
    public int rewardPoints;
    public int penaltyPoints;
    public GUISkin skin;

    private Scorekeeper scorekeeper;
    private bool targetIsRed;
    private float switchTimer;
    
    private void TimeUp()
    {
        enabled = false;
    }
    private void StartGame()
    {
    enabled = true;
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scorekeeper = GetComponent<Scorekeeper>();
        targetIsRed = true;
        switchTimer = switchInterval;

        
    }

    // Update is called once per fram

    void Update()
    {
        switchTimer -= Time.deltaTime;
        if(switchTimer < 0.0f)
        {
            targetIsRed = !targetIsRed;
            switchTimer = switchInterval;
        }
        
    }

    private string GetTargetColorName()
    {
        return targetIsRed ? "Red" : "Blue";
    }

    private void OnDestroyBox(string boxColorName)
    {

        if (boxColorName == GetTargetColorName())
        {
            scorekeeper.score += rewardPoints;
        }
        else
        {
            scorekeeper.score -= penaltyPoints;
        }
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        if (switchTimer < 1.5f)
            return;
        int sw = Screen.width;
        int sh = Screen.height;
        string message = "Shoot " + GetTargetColorName() + " Boxes";
        GUI.color = targetIsRed ? Color.red : Color.blue;
        //GUI.Label(new Rect(0, sw / 4, sw, sh / 2), message);
        GUI.Label(new Rect(0, sw / 4, sw, sh / 2), message, "Message");
    }



}
