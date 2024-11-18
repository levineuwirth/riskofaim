using UnityEngine;

public class ScorePanelController : MonoBehaviour {
    
    [field: SerializeField] public GameObject scorePanel;

    private void Start() {
        Timer.EOnTimerStop += EnterScoreScreen;
        PlayerHealth.EOnPlayerDeath += EnterScoreScreen;
        scorePanel.SetActive(false);
    }

    public void EnterScoreScreen() {
        scorePanel.SetActive(true);
        PauseManager.Pause();
    }

    public void ExitScoreScreen() {
        scorePanel.SetActive(false);
        PauseManager.Unpause();
    }

    private void OnDestroy() {
        Timer.EOnTimerStop -= EnterScoreScreen;
        PlayerHealth.EOnPlayerDeath -= EnterScoreScreen;
    }
}