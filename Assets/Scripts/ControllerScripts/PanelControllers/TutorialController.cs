using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [field: SerializeField] public GameObject tutorialPanel {get; private set;}

    private void Start() {
        tutorialPanel.SetActive(true);
        PauseManager.Pause();
    }

    public void ExitTutorialPanel() {
        tutorialPanel.SetActive(false);
        PauseManager.Unpause();
    }
}
