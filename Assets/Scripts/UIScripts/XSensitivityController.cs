using UnityEngine;
using UnityEngine.UI;
public class XSensitivityController : SensitivityController {
    protected override void OnSliderChange(float number) {
        base.OnSliderChange(number);

        PlayerPrefs.SetFloat("currentSensitivityX", mouseSensitivity);
    }

    protected override void Start() {
        mouseSensitivity = PlayerPrefs.GetFloat("currentSensitivityX", 5f);
        base.Start();
    }
}