using UnityEngine;

public class RoundController : MonoBehaviour
{
    public delegate void StartRound();
    public static StartRound EStartRound;
    public delegate void GameEnd();
    public static GameEnd EGameEnd;
    public delegate void OnLastRound();
    public static OnLastRound EOnLastRound;
    public delegate void UpSpawnTick();
    public static UpSpawnTick EUpSpawnTick;
    [field: SerializeField] public Round round {get; private set;}

    // Grey, Blue, Red, Green
    [field: SerializeField] public int[] targetWeightModifiers{get; private set;}
    [field: SerializeField] public int[] targetMinimumRound {get; private set;}
    [field: SerializeField] public int setMaxRound {get; private set;}
    private static int currentRoundNumber;
    private static int maxRound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EStartRound += ModifyRound;
        EOnLastRound += LastRound;

        currentRoundNumber = 1;
        maxRound = setMaxRound;
    }

    private void ModifyRound() {
        currentRoundNumber++;

        if(currentRoundNumber == maxRound) {
            EOnLastRound?.Invoke();
        }

        // if(currentRoundNumber > 7) {
        //     EUpSpawnTick?.Invoke();
        // }
        EUpSpawnTick?.Invoke();

        for(int i = 0; i < targetWeightModifiers.Length; i++) {
            if(currentRoundNumber >= targetMinimumRound[i]) {
                round.targetSpawnWeights[i] += targetWeightModifiers[i];
            }
        }
    }
    private void EndGame() {
        EGameEnd?.Invoke();
    }
    private void LastRound() {
        Timer.EOnRoundEnd += EndGame;
    }

    public static int GetCurrentRoundNumber() {
        return currentRoundNumber;
    }
    public static int GetMaxRoundNumber() {
        return maxRound;
    }
    public void StartNextRound() {
        EStartRound?.Invoke();
    }

    private void OnDestroy() {
        EStartRound -= ModifyRound;
        EOnLastRound -= LastRound;
        Timer.EOnRoundEnd -= EndGame;
    }
}