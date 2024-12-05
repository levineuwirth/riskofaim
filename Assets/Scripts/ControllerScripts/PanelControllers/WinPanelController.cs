using UnityEngine;

public class WinPanelController : MonoBehaviour {

    [field: SerializeField] public GameObject panel {get; private set;}

    private void Start() {
        RoundController.EGameEnd += OpenWinScreen;
        panel.SetActive(false);
    }

    public void OpenWinScreen() {
        panel.SetActive(true);
        PauseManager.Pause();
    }

    public void CloseWinScreen() {
        panel.SetActive(false);
        PauseManager.Pause();
    }

    private void OnDestroy() {
        PlayerHealth.EOnPlayerDeath -= OpenWinScreen;
    }

}