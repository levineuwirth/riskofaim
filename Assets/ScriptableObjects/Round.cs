using UnityEngine;

[CreateAssetMenu(fileName = "Round", menuName = "Scriptable Objects/Round")]
public class Round : ScriptableObject
{
    // Grey, Blue (Shield), Red (Don't Shoot), Green (Heal)
    [field: SerializeField] public int[] targetSpawnWeights {get; private set;}
    [field: SerializeField] public int roundDurationInSeconds {get; private set;}

}
