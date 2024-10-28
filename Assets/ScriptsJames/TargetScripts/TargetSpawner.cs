using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour
{

    [field: SerializeField] public float spawnYMax;
    [field: SerializeField] public float spawnYMin;
    [field: SerializeField] public float spawnXMax;
    [field: SerializeField] public float spawnXMin;
    [field: SerializeField] public float spawnRate;
    [field: SerializeField] public GameObject TargetPrefab;

    private float lastSpawnTime = 0;

    void Update()
    {
        if (lastSpawnTime + 1 / spawnRate < Time.time)
        {
            lastSpawnTime = Time.time;
            Vector3 spawnPosition = new Vector3(Random.Range(spawnXMin, spawnXMax), Random.Range(spawnYMin, spawnYMax), 0.0f);
            Instantiate(TargetPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
