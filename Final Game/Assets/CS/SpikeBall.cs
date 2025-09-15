using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            other.gameObject.SendMessageUpwards("ApplyDamage", 10, SendMessageOptions.DontRequireReceiver);
        }

        Destroy(gameObject);
    }
}
