using UnityEngine;

public class Round : MonoBehaviour {
    [field: SerializeField] public int[] targetSpawnWeights {get; private set;}
    [field: SerializeField] public int roundDurationInSeconds {get; private set;}
    [field: SerializeField] public int scoreThreshold {get; private set;}
}