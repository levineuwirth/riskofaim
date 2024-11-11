using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [field: SerializeField] public GameObject tutorialPanel {get; private set;}

    private void Start() {
        tutorialPanel.SetActive(true);

        Time.timeScale = 0;
    }

    public void ExitTutorialPanel() {
        tutorialPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
