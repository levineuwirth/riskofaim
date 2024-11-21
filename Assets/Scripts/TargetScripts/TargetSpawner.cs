using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour
{
    [field: SerializeField] public float xSpawnRange {get; private set;}
    [field: SerializeField] public float ySpawnRange {get; private set;}
    [field: SerializeField] public float spawnRate = 0.1f;
    [field: SerializeField] public GameObject RedTargetPrefab;
    [field: SerializeField] public GameObject GreenTargetPrefab;
    [field: SerializeField] public GameObject BlueTargetPrefab;
    [field: SerializeField] public GameObject GreyTargetPrefab;
    [field: SerializeField] public Round round;
    public static TargetSpawner Instance { get; private set; }
    private float lastSpawnTime = 0;
    private int targetType;
    private bool targetFound;
    private System.Random _random;
    [field: SerializeField] LayerMask targetLayerMask;
    private bool targetSpawned;
    private int greySpawnWeight;
    private int blueSpawnWeight;
    private int redSpawnWeight;
    private int greenSpawnWeight;


    private void Start()
    {
        targetLayerMask = LayerMask.GetMask("Target");
        Instance = this;
    }

    void Update()
    {
        if (Time.time - lastSpawnTime >= spawnRate)
        {
            SpawnTarget();
            if (targetSpawned)
            {
                lastSpawnTime = Time.time;
            }
        }
    }

    private void SpawnTarget()
    {
        targetType = Random.Range(0, 100);
        lastSpawnTime = Time.time;
        Vector3 spawnPosition = new Vector3(Random.Range(transform.position.x - xSpawnRange, transform.position.x + xSpawnRange), Random.Range(transform.position.y - ySpawnRange, transform.position.y + ySpawnRange), transform.position.z);
        Collider[] hitColliders = Physics.OverlapSphere(spawnPosition, 1, targetLayerMask);
        Debug.Log(hitColliders.Length);
        if (hitColliders.Length == 0)
        {
            targetSpawned = true;
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
        else
        {
            targetSpawned = false;

        }
    }

    private int FindSpawnWeight(int n)
    {
        int spawnWeight = 0;
        for(int i = 0; i > n; i++)
        {
            spawnWeight += round.targetSpawnWeights[n];
        }
        return spawnWeight;
    }

    public void SpawnRound() {
        //implement spawn behavior per round
    }

    public void SetTargetFound(bool targetFind)
    {
        targetFound = targetFind;
    }

    public void IncreaseSpawnRate() {
        spawnRate += 0.25f;
    }
}
