using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SendMessage("ApplyDamage", 10);
        Destroy(gameObject);
    }
}
