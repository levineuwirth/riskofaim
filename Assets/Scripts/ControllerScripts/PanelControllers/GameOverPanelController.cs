using UnityEngine;

public class GameOverPanelController : MonoBehaviour {

    [field: SerializeField] public GameObject panel {get; private set;}

    private void Start() {
        PlayerHealth.EOnPlayerDeath += OpenGameOverScreen;
        panel.SetActive(false);
    }

    public void OpenGameOverScreen() {
        panel.SetActive(true);
        PauseManager.Pause();
    }

    public void CloseGameOverScreen() {
        panel.SetActive(false);
        PauseManager.Pause();
    }

    private void OnDestroy() {
        PlayerHealth.EOnPlayerDeath -= OpenGameOverScreen;
    }

}