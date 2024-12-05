using TMPro;
using UnityEngine;

public class Score : MonoBehaviour {

    [field: SerializeField] public int scoreIncrement {get; private set;}
    private static int _score;
    void Start() {
        PlayerShoot.EOnTargetHit += AddScore;
        _score = 0;
    }
    public static int GetScore() {
        return _score;
    }
    private void AddScore() {
        _score += scoreIncrement;
        Debug.Log(_score);
    }
    private void OnDestroy() {
        PlayerShoot.EOnTargetHit -= AddScore;
    }
}