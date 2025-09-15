using UnityEngine;

public class GravityController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity =
            Quaternion.AngleAxis(Input.GetAxis("Horizontal") * 60.0f, Vector3.forward) *
            Quaternion.AngleAxis(Input.GetAxis("Vertical") * -60.0f, Vector3.right) *
            (Vector3.up * -20.0f);
    }
}
