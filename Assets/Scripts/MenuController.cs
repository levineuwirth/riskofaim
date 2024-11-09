using UnityEngine;

public class MenuController : MonoBehaviour {
    
    [field: SerializeField] public GameObject scorePanel;

    private void Start() {
        Timer.EOnTimerStop += EnterScoreScreen;
        scorePanel.SetActive(false);
    }

    private void EnterScoreScreen() {
        scorePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void ExitScoreScreen() {
        scorePanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnDestroy() {
        Timer.EOnTimerStop -= EnterScoreScreen;
    }
}