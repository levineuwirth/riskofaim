using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarUI : MonoBehaviour
{
    private Slider _slider;
    
    void Start()
    {
        _slider = gameObject.GetComponent<Slider>();
    }

    public void SetMaxHealth(int maxHealth) {
        _slider.maxValue = maxHealth;
        _slider.value = maxHealth;
    }
    public void UpdateHealth(int health) {
        _slider.value = health;
    }
}
