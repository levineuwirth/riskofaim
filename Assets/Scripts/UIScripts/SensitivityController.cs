using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SensitivityController : MonoBehaviour {
    private Slider _sensitivitySlider;
    private float _mouseSensitivity;

    private void Start() {
        _sensitivitySlider = gameObject.GetComponent<Slider>();
        _mouseSensitivity = PlayerPrefs.GetFloat("currentSensitivity", 5f);
    }
    private void Update() {
        PlayerPrefs.SetFloat("currentSensitivity", _mouseSensitivity);
    }
}