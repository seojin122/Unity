using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float spawnInterval = 5f;
    public Vector3 areaSize = new Vector3(10f, 0f, 10f);
    public float spawnHeight = 20f;

    private float timer = 0f;
    private int spawnCount = 0;

    void Start()
    {
        if (zombiePrefab == null)
        {
            Debug.LogError("좀비 프리팹이 할당되지 않았습니다.");
        }

        RemoveExistingZombies();
    }

    void Update()
    {
        if (zombiePrefab == null || spawnCount >= 2) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnZombie();
            spawnCount++;
            timer = 0f;
        }
    }

    void SpawnZombie()
    {
        Vector3 randomPosition = GetRandomPositionInArea();
        Vector3 rayStart = randomPosition + Vector3.up * spawnHeight;
        float rayDistance = spawnHeight + 10f;

        if (Physics.Raycast(rayStart, Vector3.down, out RaycastHit hit, rayDistance))
        {
            Vector3 spawnPoint = hit.point;
            GameObject zombie = Instantiate(zombiePrefab, spawnPoint, Quaternion.identity);
            zombie.tag = "Zombie";
        }
    }

    void RemoveExistingZombies()
    {
        GameObject[] existingZombies = GameObject.FindGameObjectsWithTag("Zombie");
        foreach (GameObject zombie in existingZombies)
        {
            if (zombie != zombiePrefab)
            {
                Destroy(zombie);
            }
        }
    }

    Vector3 GetRandomPositionInArea()
    {
        Vector3 center = transform.position;
        float x = Random.Range(-areaSize.x * 0.5f, areaSize.x * 0.5f);
        float z = Random.Range(-areaSize.z * 0.5f, areaSize.z * 0.5f);
        return new Vector3(center.x + x, center.y, center.z + z);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(areaSize.x, 1f, areaSize.z));
    }
}
