using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [field: SerializeField] public int maxHealth {get; private set;}
    [field: SerializeField] public int baseDamage {get; private set;}
    [field: SerializeField] public int damageModifier {get; private set;}
    [field: SerializeField] public int baseHeal {get; private set;}
    [field: SerializeField] public int healModifier {get; private set;}
    private int currentHealth;
    private void Start() {
        currentHealth = maxHealth;
	PlayerShoot.EOnTargetMiss += takeDamage;
	damageModifier = 1;
	baseDamage = 1;
    }
    
    public void takeDamage() {
        currentHealth -= damageModifier * baseDamage;
	Debug.Log("DAMAGE!");
    }
    public void heal() {
        currentHealth += healModifier * baseHeal;
    }
    public void increaseMaxHealth(int health) {
        maxHealth += health;
    }
    public void setCurrentHealth(int health) {
        currentHealth = maxHealth;
    }
}
