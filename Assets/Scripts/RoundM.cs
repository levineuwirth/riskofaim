using UnityEngine;

public class RoundM : MonoBehaviour {
    [field: SerializeField] public int[] targetSpawnWeights {get; private set;}
    [field: SerializeField] public int roundDurationInSeconds {get; private set;}
}