using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour
{

    [field: SerializeField] public float xSpawnRange {get; private set;}
    [field: SerializeField] public float ySpawnRange {get; private set;}
    [field: SerializeField] public float spawnRate;
    [field: SerializeField] public GameObject TargetPrefab;

    private float lastSpawnTime = 0;

    void Update()
    {
        if (lastSpawnTime + 1 / spawnRate < Time.time)
        {
            lastSpawnTime = Time.time;
            Vector3 spawnPosition = new Vector3(Random.Range(transform.position.x - xSpawnRange, transform.position.x + xSpawnRange), Random.Range(transform.position.y - ySpawnRange, transform.position.y + ySpawnRange), transform.position.z);
            Instantiate(TargetPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
