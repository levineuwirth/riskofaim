using UnityEngine;
using TMPro;

public class RoundUI : MonoBehaviour {

    private TextMeshProUGUI _roundText;

    void Start() {
        _roundText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update() {
        _roundText.text = "Round " + RoundController.GetCurrentRoundNumber().ToString() + " of " + RoundController.GetMaxRoundNumber().ToString();
    }

}