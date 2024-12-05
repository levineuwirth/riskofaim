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
    [field: SerializeField] public Button settingsToMainMenuButton {get; private set;}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        restartFromRoundOver.onClick.AddListener(RestartWithPause);
        restartFromGameOver.onClick.AddListener(RestartScene);
        exitFromGameOver.onClick.AddListener(EnterMainMenu);
        restartFromWin.onClick.AddListener(RestartWithPause);
        exitToMainMenuButton.onClick.AddListener(EnterMainMenu);
        settingsToMainMenuButton.onClick.AddListener(EnterMainMenu);
    }

    private void EnterGame() {
        SceneController.Instance.LoadScene("Game");
    }
    private void EnterTutorial() {
        SceneController.Instance.LoadScene("Tutorial");
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
