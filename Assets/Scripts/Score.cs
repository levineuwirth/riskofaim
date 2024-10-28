using TMPro;
using UnityEngine;

public class Score : MonoBehaviour {

    [field: SerializeField] public TextMeshProUGUI scoreText {get; private set;}
    private int _score;

    void Start() {
        _score = 0;
        PlayerShoot.EOnTargetHit += addScore;
    }
    void Update() {
        scoreText.text = "Score: " + _score.ToString();
    }
    private void addScore() {
        _score += 100;
    }

    private void OnDestroy() {
        PlayerShoot.EOnTargetHit -= addScore;
    }
}