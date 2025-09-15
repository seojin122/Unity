using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            other.gameObject.SendMessageUpwards("CatchCoin", 1, SendMessageOptions.DontRequireReceiver);
        }

        Destroy(gameObject);
    }
}
