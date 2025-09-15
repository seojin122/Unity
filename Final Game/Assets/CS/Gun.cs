using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (cam != null && Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Vector3 spawnPos = cam.transform.position + cam.transform.forward * 1f;

        Vector3 shootDir = ray.direction;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            shootDir = (hit.point - spawnPos).normalized;
        }

        if (shootDir == Vector3.zero)
        {
            shootDir = cam.transform.forward;
        }

        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.LookRotation(shootDir));

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = shootDir * bulletSpeed;
        }

        Destroy(bullet, bulletLifetime);
    }
}
