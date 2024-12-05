using System.Runtime.ExceptionServices;
using UnityEngine;

public class Round : MonoBehaviour {
    [field: SerializeField] public int[] targetSpawnWeights {get; private set;}
    [field: SerializeField] public int roundDurationInSeconds {get; private set;}
    public void EditSpawnWeights(int index, int weight) {
        targetSpawnWeights[index] = weight;
    }
    public void SetSpawnWeights(int grey, int blue, int red, int green) {
        targetSpawnWeights[0] = grey;
        targetSpawnWeights[1] = blue;
        targetSpawnWeights[2] = red;
        targetSpawnWeights[3] = green;
    }
}