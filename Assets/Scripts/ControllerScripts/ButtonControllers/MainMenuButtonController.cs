using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class MainMenuButtonController : MonoBehaviour
{

    [field: SerializeField] public Button playButton {get; private set;}
    [field: SerializeField] public Button tutorialButton {get; private set;}
    [field: SerializeField] public Button exitButton {get; private set;}
    void Start()
    {
        playButton.onClick.AddListener(EnterGame);
        tutorialButton.onClick.AddListener(EnterTutorial);
        exitButton.onClick.AddListener(CloseApp);
    }

    private void EnterGame() {
        SceneController.Instance.LoadScene("Game");
    }
    private void EnterTutorial() {
        SceneController.Instance.LoadScene("Tutorial");
    }
    private void CloseApp() {
        SceneController.Instance.QuitApp();
    }
}
