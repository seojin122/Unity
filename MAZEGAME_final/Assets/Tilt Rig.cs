using UnityEngine;

public class TiltRig : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation =
            Quaternion.AngleAxis(Input.GetAxis("Horizontal") * 10.0f, Vector3.forward) *
            Quaternion.AngleAxis(Input.GetAxis("Vertical") * -10.0f, Vector3.right);
    }
}
