using UnityEngine;

public class SettingsController : MonoBehaviour {
    [field: SerializeField] public GameObject settingsPanel {get; private set;}
    private bool _isSettingsOpen;

    private void Start() {
        settingsPanel.SetActive(false);
    }
    private void Update() {
        if(Input.GetKeyDown(PlayerController.Instance.pause)) {
            if(!_isSettingsOpen) {
                OpenSettings();
                PauseManager.Pause();
            }
            else {
                CloseSettings();
                PauseManager.Unpause();
            }
        }
    }
    public void OpenSettings() {
        settingsPanel.SetActive(true);
        _isSettingsOpen = true;
    }
    public void CloseSettings() {
        settingsPanel.SetActive(false);
        _isSettingsOpen = false;
    }
}