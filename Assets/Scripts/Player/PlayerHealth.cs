using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [field: SerializeField] public int maxHealth {get; private set;}
    private int currentHealth;

    private void Start() {
        currentHealth = maxHealth;
    }
    
    public void takeDamage(int damage) {
        currentHealth -= damage;
    }
    public void heal(int heal) {
        currentHealth += heal;
    }
    public void increaseMaxHealth(int health) {
        maxHealth += health;
    }
    public void setCurrentHealth(int health) {
        currentHealth = maxHealth;
    }
}