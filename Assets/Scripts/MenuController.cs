using UnityEngine;

public class MenuController : MonoBehaviour {
    
    [field: SerializeField] public GameObject scorePanel;

    private void Start() {
        Timer.EOnTimerStop += EnterScoreScreen;
        scorePanel.SetActive(false);
    }

    private void EnterScoreScreen() {
        scorePanel.SetActive(true);
    }

    private void ExitScoreScreen() {
        scorePanel.SetActive(false);
    }

    private void OnDestroy() {
        Timer.EOnTimerStop -= EnterScoreScreen;
    }
}