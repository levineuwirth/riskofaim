using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour
{

    [field: SerializeField] public float xSpawnRange {get; private set;}
    [field: SerializeField] public float ySpawnRange {get; private set;}
    [field: SerializeField] public float spawnRate;
    [field: SerializeField] public GameObject TargetFinderPrefab;
    [field: SerializeField] public GameObject RedTargetPrefab;
    [field: SerializeField] public GameObject GreenTargetPrefab;
    [field: SerializeField] public GameObject BlueTargetPrefab;
    [field: SerializeField] public GameObject GreyTargetPrefab;
    public static TargetSpawner Instance { get; private set; }

    private float lastSpawnTime = 0;
    private int targetType;
    private bool targetFound;

    private void Start()
    {
        Instance = this;
    }

    void Update()
    {
        if (lastSpawnTime + 1 / spawnRate < Time.time)
        {
            targetType = Random.Range(0, 4);
            lastSpawnTime = Time.time;
            Vector3 spawnPosition = new Vector3(Random.Range(transform.position.x - xSpawnRange, transform.position.x + xSpawnRange), Random.Range(transform.position.y - ySpawnRange, transform.position.y + ySpawnRange), transform.position.z);
            Instantiate(TargetFinderPrefab, spawnPosition, Quaternion.identity);
            Debug.Log(targetFound);
            if (!targetFound)
            {
                if (targetType == 0)
                {
                    Instantiate(RedTargetPrefab, spawnPosition, Quaternion.identity);
                }
                else if (targetType == 1)
                {
                    Instantiate(BlueTargetPrefab, spawnPosition, Quaternion.identity);
                }
                else if (targetType == 2)
                {
                    Instantiate(GreenTargetPrefab, spawnPosition, Quaternion.identity);
                }
                else if (targetType == 3)
                {
                    Instantiate(GreyTargetPrefab, spawnPosition, Quaternion.identity);
                }
            }
        }
    }

    public void SetTargetFound(bool targetFind)
    {
        targetFound = targetFind;
    }

    public void IncreaseSpawnRate() {
        spawnRate += 0.25f;
    }
}
