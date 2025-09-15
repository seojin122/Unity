using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public float changeDirTime = 3f;
    private float timer;
    private Vector3 moveDirection;
    private Animator animator;

    public AudioClip damageSound;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        PickNewDirection();
        if (animator != null)
        {
            animator.Play("Zombie Walk2");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeDirTime)
        {
            PickNewDirection();
            timer = 0f;
        }

        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(moveDirection),
                Time.deltaTime * 2f
            );
        }
    }

    void PickNewDirection()
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        moveDirection = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)).normalized;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (damageSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(damageSound);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("Player"))
        {
            if (damageSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(damageSound);
            }

            other.SendMessageUpwards("ApplyDamage", 10, SendMessageOptions.DontRequireReceiver);
        }
    }
}
