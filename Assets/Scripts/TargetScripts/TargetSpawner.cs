using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour
{
    [field: SerializeField] public float xSpawnRange {get; private set;}
    [field: SerializeField] public float ySpawnRange {get; private set;}
    [field: SerializeField] public float spawnTick {get; private set;}
    [field: SerializeField] public GameObject RedTargetPrefab;
    [field: SerializeField] public GameObject GreenTargetPrefab;
    [field: SerializeField] public GameObject BlueTargetPrefab;
    [field: SerializeField] public GameObject GreyTargetPrefab;
    [field: SerializeField] public Round round;
    public static TargetSpawner Instance { get; private set; }
    private float lastSpawnTime = 0;
    private int targetType;
    private System.Random _random;
    private LayerMask targetLayerMask;
    private int greySpawnWeight;
    private int blueSpawnWeight;
    private int redSpawnWeight;
    private int greenSpawnWeight;

    private void Start()
    {
        targetLayerMask = LayerMask.GetMask("Target");
        Instance = this;

        greySpawnWeight = FindSpawnWeight(0);
        blueSpawnWeight = FindSpawnWeight(1);
        redSpawnWeight = FindSpawnWeight(2);
        greenSpawnWeight = FindSpawnWeight(3);
    }

    void Update()
    {
        if (Time.time - lastSpawnTime >= spawnTick)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(transform.position.x - xSpawnRange, transform.position.x + xSpawnRange), Random.Range(transform.position.y - ySpawnRange, transform.position.y + ySpawnRange), transform.position.z);

            Collider[] hitColliders = Physics.OverlapSphere(spawnPosition, 1, targetLayerMask);

            if(hitColliders.Length == 0) {
                SpawnTarget(spawnPosition);

                lastSpawnTime = Time.time;
            }
        }
    }

    private void SpawnTarget(Vector3 spawnPosition)
    {
        targetType = Random.Range(0, greenSpawnWeight);
        lastSpawnTime = Time.time;

        if (targetType <= greySpawnWeight)
        {
            Instantiate(GreyTargetPrefab, spawnPosition, Quaternion.identity);
        }
        else if (targetType <= blueSpawnWeight)
        {
            Instantiate(BlueTargetPrefab, spawnPosition, Quaternion.identity);
        }
        else if (targetType <= redSpawnWeight)
        {
            Instantiate(RedTargetPrefab, spawnPosition, Quaternion.identity);
        }
        else if (targetType <= greenSpawnWeight)
        {
            Instantiate(GreenTargetPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private int FindSpawnWeight(int n)
    {
        int spawnWeight = 0;
        for(int i = 0; i <= n; i++)
        {
            spawnWeight += round.targetSpawnWeights[n];
        }
        return spawnWeight;
    }

    public void IncreaseSpawnRate() {
        spawnTick -= 0.1f;
    }
}
