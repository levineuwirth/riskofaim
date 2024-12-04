using UnityEngine;

public class TutorialRoundController : RoundController {
    protected override void ModifyRound()
    {
        currentRoundNumber++;

        Debug.Log(currentRoundNumber);

        if(currentRoundNumber == maxRound) {
            EOnLastRound?.Invoke();
        }

        EUpSpawnTick?.Invoke();

        round.SetSpawnWeights(1, 1, 1, 1);

        switch(currentRoundNumber) {
            case 1: 
                round.EditSpawnWeights(0, 1000);
                break;
            case 2:
                round.EditSpawnWeights(1, 1000);
                break;
            case 3:
                round.EditSpawnWeights(2, 1000);
                break;
            case 4:
                round.EditSpawnWeights(3, 1000);
                break;
            case 5:
                round.SetSpawnWeights(1, 1, 1, 1);
                break;
            default:
                break;
        }

        foreach(int weight in round.targetSpawnWeights) {
            Debug.Log(weight);
        }
    }
}