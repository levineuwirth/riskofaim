using UnityEngine;

[CreateAssetMenu(fileName = "Round", menuName = "Scriptable Objects/Round")]
public class Round : ScriptableObject
{
    // ensure that both arrays are the same size
    [field: SerializeField] public Target[] targetTypes {get; private set;}
    [field: SerializeField] public int[] chanceToSpawnTarget {get; private set;}

}
