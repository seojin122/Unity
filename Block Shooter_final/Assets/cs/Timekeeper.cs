using Unity.Hierarchy;
using UnityEngine;

public class Timekeeper : MonoBehaviour
{
    public float gameLength;
    private float elapsed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void StartGame()
    {
        enabled = true;
    }

    // Update is called once per frame

    void Update()
    {

         elapsed += Time.deltaTime;
         if(elapsed > gameLength){
             BroadcastMessage("TimeUp");
             GameObject.FindWithTag("MainCamera").SendMessage("TimeUp");
             enabled = false;
         }


    }
}
