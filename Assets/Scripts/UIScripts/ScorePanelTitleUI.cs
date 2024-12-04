using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScorePanelTitleUI : MonoBehaviour {

    private TextMeshProUGUI _titleText;

    void Start() {
        _titleText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update() {
        _titleText.text = "Round " + RoundController.GetCurrentRoundNumber().ToString() + " Complete";
    }

}