using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Score : MonoBehaviour {

    [field: SerializeField] public int scoreIncrement {get; private set;}
    // edit to attach to one class and have another class that UI's can use to display the score.
    private static int _score;
    private TextMeshProUGUI _scoreText;

    void Start() {
        _scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        _score = 0;
        PlayerShoot.EOnTargetHit += addScore;
    }
    void Update() {
        _scoreText.text = _score.ToString();
    }
    private void addScore() {
        _score += scoreIncrement;
    }

    private void OnDestroy() {
        PlayerShoot.EOnTargetHit -= addScore;
    }
}