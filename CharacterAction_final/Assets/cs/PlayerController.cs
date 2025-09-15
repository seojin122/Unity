using System.Collections;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float gravity = 20.0f;
    public float jumpSwpeed = 8.0f;
    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Animation>()["Walk"].speed = walkSpeed;
        //StartCoroutine (AnimationSession());
    }
    /*
    IEnumerator AnimationSession()
    {
        GetComponent<Animation>()["Walk"].speed = 4.0f;
        GetComponent<Animation>().Play("Walk");
        yield return new WaitForSeconds(2.0f);
        GetComponent<Animation>().CrossFade("Crouch");
        yield return new WaitForSeconds(2.0f);
        GetComponent<Animation>().CrossFade("Idle", 0.1f);
    }
    */



    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            velocity *= walkSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpSwpeed;
                GetComponent<Animation>().Play("Jump");
            }
           else if(velocity.magnitude > 0.5f)
            {
                GetComponent<Animation>().CrossFade("Walk", 0.1f);
                transform.LookAt(transform.position + velocity);
            }
            else
            {
                GetComponent<Animation>().CrossFade("Idle", 0.1f);
            }
        }
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
