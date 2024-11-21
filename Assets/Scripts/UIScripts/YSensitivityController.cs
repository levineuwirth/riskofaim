using UnityEngine;
using UnityEngine.UI;
public class YSensitivityController : SensitivityController {
    protected override void OnSliderChange(float number) {
        base.OnSliderChange(number);

        PlayerPrefs.SetFloat("currentSensitivityY", mouseSensitivity);
    }

    protected override void Start() {
        mouseSensitivity = PlayerPrefs.GetFloat("currentSensitivityY", 5f);
        base.Start();
    }
}