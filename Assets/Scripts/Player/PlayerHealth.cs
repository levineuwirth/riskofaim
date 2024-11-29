using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public delegate void OnPlayerDeath();
    public static OnPlayerDeath EOnPlayerDeath;
    [field: SerializeField] public int maxHealth {get; private set;}
    [field: SerializeField] public int baseDamage {get; private set;}
    [field: SerializeField] public int damageModifier {get; private set;}
    [field: SerializeField] public int baseHeal {get; private set;}
    [field: SerializeField] public int healModifier {get; private set;}
    [field: SerializeField] public HealthBarUI healthBar {get; private set;}
    private int currentHealth;
    private void Start() {
	    Target.EOnTargetDespawn += takeDamage;
        RedTarget.EOnRedTargetHit += takeDamage;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

	    damageModifier = 1;
	    baseDamage = 1;
    }

    private void Update() {
        if(currentHealth < 1) {
            EOnPlayerDeath?.Invoke();
        }
    }
    
    public void takeDamage() {
        currentHealth -= damageModifier * baseDamage;
        healthBar.UpdateHealth(currentHealth);
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

    private void OnDestroy() {
        Target.EOnTargetDespawn -= takeDamage;
        RedTarget.EOnRedTargetHit -= takeDamage;
    }
}
