using System;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityController : MonoBehaviour {
    [field: SerializeField] public Slider sensitivitySlider {get; private set;}
    [field: SerializeField] public TMP_InputField sensitivityInput {get; private set;}
    protected float mouseSensitivity = 5f;

    private void Awake() {
        sensitivitySlider.onValueChanged.AddListener(OnSliderChange);
        sensitivityInput.onValueChanged.AddListener(OnFieldChange);
    }
    protected virtual void Start() {
        sensitivitySlider.value = mouseSensitivity;
    }

    protected virtual void OnSliderChange(float number) {
        mouseSensitivity = number;
        
        if(sensitivityInput.text != number.ToString()) {
            sensitivityInput.text = number.ToString("0.000");
        }
    }


    protected void OnFieldChange(string text) {
        if(sensitivitySlider.value.ToString() != text) {
            if (float.TryParse(text, out float number))
            {
                sensitivitySlider.value = number;
            }
        }
    }
}