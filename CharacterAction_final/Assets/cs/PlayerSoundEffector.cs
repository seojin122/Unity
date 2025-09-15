using UnityEngine;

public class PlayerSoundEffector : MonoBehaviour
{
    public AudioClip coinAudioSource;
    public AudioClip damageAudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CatchCoin(int amount)
    {
        GetComponent<AudioSource>().Play();
    }

    void ApplyDamage(int amount)
    {
        GetComponent<AudioSource>().PlayOneShot(damageAudioSource);
    }
}
