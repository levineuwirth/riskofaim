using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class AmmoUI : MonoBehaviour {

    private TextMeshProUGUI _ammoText;

    void Start() {
        _ammoText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        _ammoText.text = PlayerAmmo.GetCurrentAmmo().ToString() + "/" + PlayerAmmo.GetMaxAmmo().ToString();
    }
}