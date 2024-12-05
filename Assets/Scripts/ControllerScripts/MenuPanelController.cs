using UnityEditor;
using UnityEngine;

public class MenuPanelController : MonoBehaviour
{
    [field: SerializeField] public GameObject menuPanel {get; private set;}

    private void Start() {
        menuPanel.SetActive(true);
        PauseManager.Pause();
    }

    public void ExitMenuPanel() {
        menuPanel.SetActive(false);
        PauseManager.Unpause();
    }
}
