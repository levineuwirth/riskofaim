using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreUI : MonoBehaviour {

    private TextMeshProUGUI _scoreText;

    void Start() {
        _scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update() {
        _scoreText.text = Score.GetScore().ToString();
    }
}