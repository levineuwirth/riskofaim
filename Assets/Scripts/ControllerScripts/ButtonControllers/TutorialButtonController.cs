using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class TutorialButtonController : MonoBehaviour
{
    [field: SerializeField] public Button roundOverRestartTutorial {get; private set;}
    [field: SerializeField] public Button gameOverRestartTutorial {get; private set;}
    [field: SerializeField] public Button gameOverToMainMenu {get; private set;}
    [field: SerializeField] public Button finishRestartTutorial {get; private set;}
    [field: SerializeField] public Button finishToMainMenu {get; private set;}
    [field: SerializeField] public Button startToMainMenu {get; private set;}

    private void Start()
    {
        roundOverRestartTutorial.onClick.AddListener(RestartScene);
        gameOverRestartTutorial.onClick.AddListener(RestartScene);
        gameOverToMainMenu.onClick.AddListener(EnterMainMenu);
        finishRestartTutorial.onClick.AddListener(RestartScene);
        finishToMainMenu.onClick.AddListener(EnterMainMenu);
        startToMainMenu.onClick.AddListener(EnterMainMenu);
    }
    private void EnterMainMenu() {
        SceneController.Instance.LoadScene("Main Menu");
    }
    private void RestartScene() {
        SceneController.Instance.ReloadScene();
    }
}
