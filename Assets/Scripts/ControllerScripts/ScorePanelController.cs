using UnityEngine;

public class ScorePanelController : MonoBehaviour {
    
    [field: SerializeField] public GameObject scorePanel;

    private void Start() {
        Timer.EOnTimerStop += EnterScoreScreen;
        scorePanel.SetActive(false);
    }

    public void EnterScoreScreen() {
        scorePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ExitScoreScreen() {
        scorePanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnDestroy() {
        Timer.EOnTimerStop -= EnterScoreScreen;
    }
}