using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityController : MonoBehaviour {
    [field: SerializeField] public TextMeshProUGUI xSensitivityText {get; private set;}
    [field: SerializeField] public TextMeshProUGUI ySensitivityText {get; private set;}
    [field: SerializeField] public Slider xSensitivitySlider {get; private set;}
    [field: SerializeField] public Slider ySensitivitySlider {get; private set;}
    private float _xMouseSensitivity = 5f;
    private float _yMouseSensitivity = 5f;

    private void Start() {
        _xMouseSensitivity = PlayerPrefs.GetFloat("currentSensitivityX", 5f);
        xSensitivitySlider.value = _xMouseSensitivity;
        
        _yMouseSensitivity = PlayerPrefs.GetFloat("currentSensitivityY", 5f);
        ySensitivitySlider.value = _yMouseSensitivity;

    }
    private void Update() {
        PlayerPrefs.SetFloat("currentSensitivityX", _xMouseSensitivity);
        _xMouseSensitivity = xSensitivitySlider.value;
        xSensitivityText.text = xSensitivitySlider.value.ToString("0.000");

        PlayerPrefs.SetFloat("currentSensitivityY", _yMouseSensitivity);
        _yMouseSensitivity = ySensitivitySlider.value;
        ySensitivityText.text = ySensitivitySlider.value.ToString("0.000");
    }
}