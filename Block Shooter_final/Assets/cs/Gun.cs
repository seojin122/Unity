using System.Runtime.CompilerServices;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float initialVelocity = 40.0f;
    public Camera mainCamera;

    private void TimeUp()
    {
        enabled = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //Vector3 direction = transform.forward;

            Vector3 screenPoint = Input.mousePosition;
            screenPoint.z = 10.0f;
            Vector3 worldPoint = mainCamera.ScreenToWorldPoint(screenPoint);
            Vector3 direction = (worldPoint - transform.position).normalized;

            bullet.GetComponent<Rigidbody>().linearVelocity = initialVelocity * direction;
        }
    }
}
