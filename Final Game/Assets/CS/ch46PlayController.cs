using UnityEngine;
using UnityEngine.SceneManagement;

public class ch46PlayController : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float gravity = 20.0f;
    public float jumpSpeed = 8.0f;
    public float rotationSpeed = 90.0f;

    private Vector3 velocity;
    private Animator animator;
    private CharacterController controller;
    private bool isGameFinished = false;

    public AudioClip jumpSound;
    public AudioClip damageSound;
    public AudioClip deathSound;
    public AudioClip scoreSound;
    public AudioClip spawnSound;
    private AudioSource audioSource;

    private Vector3 startPosition = new Vector3(-95.3f, 0.9f, 27.5f);

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null && spawnSound != null)
        {
            audioSource.PlayOneShot(spawnSound);
        }
    }

    void Update()
    {
        if (animator == null || controller == null) return;

        animator.speed = 2.0f;

        bool isGrounded = controller.isGrounded;
        animator.SetBool("Grounded", isGrounded);

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, h * rotationSpeed * Time.deltaTime);

        Vector3 move = transform.forward * v * moveSpeed;
        velocity.x = move.x;
        velocity.z = move.z;

        if (isGrounded)
        {
            if (Mathf.Abs(v) > 0.05f)
            {
                animator.SetBool("Walking", true);
                animator.SetBool("Happy", false);
            }
            else
            {
                animator.SetBool("Walking", false);
                animator.SetBool("Happy", true);
            }

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpSpeed;
                animator.SetTrigger("Jump");

                if (jumpSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(jumpSound);
                }
            }
            else
            {
                velocity.y = -1f;
            }
        }

        velocity.y -= gravity * Time.deltaTime;
        animator.SetFloat("Speed", new Vector3(velocity.x, 0, velocity.z).magnitude);
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null || audioSource == null) return;

        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("장애물 충돌! 위치 초기화");

            if (damageSound != null)
            {
                audioSource.PlayOneShot(damageSound);
            }

            ResetPlayer();
        }
        else if (other.CompareTag("Zombie"))
        {
            Debug.Log("좀비랑 부딪힘!");

            if (damageSound != null)
            {
                audioSource.PlayOneShot(damageSound);
            }
        }
        else if (other.CompareTag("finish"))
        {
            Debug.Log("도착 완료! 🎉 게임 끝!");

            if (scoreSound != null)
            {
                audioSource.PlayOneShot(scoreSound);
            }

            FinishGame();
        }
    }

    public void ResetPlayer()
    {
        if (controller == null) return;

        controller.enabled = false;
        transform.position = startPosition;
        velocity = Vector3.zero;
        controller.enabled = true;
    }

    void OnGUI()
    {
        if (isGameFinished)
        {
            int sw = Screen.width;
            int sh = Screen.height;

            GUIStyle style = new GUIStyle();
            style.fontSize = 50;
            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.MiddleCenter;

            GUI.Label(new Rect(0, 0, sw, sh), "🎉 게임 클리어!", style);
        }
    }

    void FinishGame()
    {
        Debug.Log("게임이 끝났습니다!");
        isGameFinished = true;
        Invoke("GoToTitleScreen", 3f);
    }

    void GoToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
