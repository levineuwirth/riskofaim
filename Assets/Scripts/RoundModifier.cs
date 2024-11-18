using UnityEngine;

public class RoundModifier : MonoBehaviour
{
    [field: SerializeField] public Round round {get; private set;}

    // Grey, Blue, Red, Green
    [field: SerializeField] public int[] targetWeightModifiers{get; private set;}
    [field: SerializeField] public int[] targetMinimumRound{get; private set;}
    private static int currentRoundNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Timer.EOnRoundEnd += ModifyRound;
        currentRoundNumber = 1;
    }
    
    private void ModifyRound() {
        currentRoundNumber++;

        for(int i = 0; i < targetWeightModifiers.Length; i++) {
            if(currentRoundNumber >= targetMinimumRound[i]) {
                round.targetSpawnWeights[i] += targetWeightModifiers[i];
            }
        }
    }
    public static int GetCurrentRoundNumber() {
        return currentRoundNumber;
    }
    private void OnDestroy() {
        Timer.EOnRoundEnd -= ModifyRound;
    }
}
