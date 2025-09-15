using System.Collections;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoraController : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float gravity = 20.0f;
    public float jumpSwpeed = 8.0f;
    private Vector3 velocity;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = 2.0f;
        CharacterController controller = GetComponent<CharacterController>();
        animator.SetBool("Grounded", controller.isGrounded);

        if (controller.isGrounded)
        {
            animator.SetBool("Grounded", true);
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            velocity *= walkSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpSwpeed;
                animator.SetBool("Idle", false);
                animator.SetTrigger("Jump");
            }
           else if(velocity.magnitude > 0.5f)
            {
                animator.SetBool("Idle", false);
                animator.SetBool("Grounded", true);
                transform.LookAt(transform.position + velocity);
            }
            else
            {
                animator.SetBool("Idle", true);
            }
        }
        velocity.y -= gravity * Time.deltaTime;
        animator.SetFloat("Speed", velocity.magnitude);
        controller.Move(velocity * Time.deltaTime);

    }
}
