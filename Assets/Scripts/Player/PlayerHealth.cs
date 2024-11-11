using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;

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