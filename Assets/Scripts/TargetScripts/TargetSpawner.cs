using UnityEngine;
using System.Collections;
using UnityEngine.PlayerLoop;

public class TargetSpawner : MonoBehaviour
{
    public delegate void OnClearTargetsStart();
    public static OnClearTargetsStart EOnClearTargetsStart;
    public delegate void OnClearTargetsEnd();
    public static OnClearTargetsEnd EOnClearTargetsEnd;
    [field: SerializeField] public float xSpawnRange {get; private set;}
    [field: SerializeField] public float ySpawnRange {get; private set;}
    [field: SerializeField] public float spawnTick {get; private set;}
    [field: SerializeField] public GameObject RedTargetPrefab;
    [field: SerializeField] public GameObject GreenTargetPrefab;
    [field: SerializeField] public GameObject BlueTargetPrefab;
    [field: SerializeField] public GameObject GreyTargetPrefab;
    [field: SerializeField] public Round round;
    public static TargetSpawner Instance { get; private set; }
    private bool _roundActive;
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
        Timer.EBeforeRoundEnd += StopSpawning;
        RoundController.EUpSpawnTick += IncreaseSpawnRate;
        Countdown.EActivateRound += BeginSpawning;

        targetLayerMask = LayerMask.GetMask("Target");
        Instance = this;

        CalcSpawnWeights();

        _roundActive = false;
    }

    void Update()
    {
        if(_roundActive) {
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
    }

    private void SpawnTarget(Vector3 spawnPosition)
    {
        targetType = Random.Range(0, greenSpawnWeight + 1);
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

    private void CalcSpawnWeights()
    {
        greySpawnWeight = round.targetSpawnWeights[0];
        blueSpawnWeight = greySpawnWeight + round.targetSpawnWeights[1];
        redSpawnWeight = blueSpawnWeight + round.targetSpawnWeights[2];
        greenSpawnWeight = redSpawnWeight + round.targetSpawnWeights[3];

        Debug.Log("Grey: " + greySpawnWeight);
        Debug.Log("Blue: " + blueSpawnWeight);
        Debug.Log("Red: " + redSpawnWeight);
        Debug.Log("Green: " + greenSpawnWeight);
    }

    public void IncreaseSpawnRate() {
        spawnTick -= 0.05f;
    }

    public void ClearTargets() {
        EOnClearTargetsStart?.Invoke();

        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        foreach (GameObject target in targets) {
            Destroy(target);
        }
    }
    private void BeginSpawning() {
        _roundActive = true;
        CalcSpawnWeights();
    }
    private void StopSpawning() {
        _roundActive = false;
        ClearTargets();
    }
    private void OnDestroy() {
        Timer.EBeforeRoundEnd -= StopSpawning;
        RoundController.EUpSpawnTick += IncreaseSpawnRate;
        Countdown.EActivateRound -= BeginSpawning;
    }
}
