using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthNumberUI : MonoBehaviour {

    private TextMeshProUGUI _healthText;

    void Start() {
        _healthText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update() {
        _healthText.text = PlayerHealth.GetCurrentHealth() + " / " + PlayerHealth.GetMaxHealth();
    }
}