using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameSceneButtonController : MonoBehaviour
{
    [field: SerializeField] public Button restartFromRoundOver {get; private set;}
    [field: SerializeField] public Button restartFromGameOver {get; private set;}
    [field: SerializeField] public Button exitFromGameOver {get; private set;}
    [field: SerializeField] public Button restartFromWin {get; private set;}
    [field: SerializeField] public Button exitToMainMenuButton {get; private set;}
    [field: SerializeField] public Button closeSettingsButton {get; private set;}
    [field: SerializeField] public Button settingsToMainMenu {get; private set;}

    private void Start()
    {
        restartFromRoundOver.onClick.AddListener(RestartWithPause);
        restartFromGameOver.onClick.AddListener(RestartScene);
        exitFromGameOver.onClick.AddListener(EnterMainMenu);
        restartFromWin.onClick.AddListener(RestartWithPause);
        exitToMainMenuButton.onClick.AddListener(EnterMainMenu);
        settingsToMainMenu.onClick.AddListener(EnterMainMenu);
    }
    private void EnterMainMenu() {
        SceneController.Instance.LoadScene("Main Menu");
    }
    private void RestartScene() {
        SceneController.Instance.ReloadScene();
    }
    private void RestartWithPause() {
        RestartScene();
        PauseManager.Unpause();
    }
}
