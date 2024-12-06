using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScorePanelDescription : MonoBehaviour {

    // Length should be maxRound - 1
    [field: SerializeField] public String[] roundDescriptions {get; private set;}
    private TextMeshProUGUI _descriptionText;
    private void Start() {
        _descriptionText = gameObject.GetComponent<TextMeshProUGUI>();
        RoundController.EUpdateDescription += UpdateDescription;
    }
    private void UpdateDescription() {
        if(RoundController.GetCurrentRoundNumber() < roundDescriptions.Length + 1) {
            _descriptionText.text = roundDescriptions[RoundController.GetCurrentRoundNumber() - 1];
        }
    }
    private void OnDestroy() {
        RoundController.EUpdateDescription -= UpdateDescription;
    }
}