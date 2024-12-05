using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public delegate void OnPlayerDeath();
    public static OnPlayerDeath EOnPlayerDeath;
    [field: SerializeField] public int setMaxHealth {get; private set;}
    [field: SerializeField] public int baseDamage {get; private set;}
    [field: SerializeField] public int damageModifier {get; private set;}
    [field: SerializeField] public int baseHeal {get; private set;}
    [field: SerializeField] public int healModifier {get; private set;}
    [field: SerializeField] public HealthBarUI healthBar {get; private set;}
    private static int currentHealth;
    private static int maxHealth;
    private void Start() {
        PlayerShoot.EOnTargetMiss += takeDamage;
	    Target.EOnTargetDespawn += takeDamage;
        RedTarget.EOnRedTargetHit += takeDamage;
        GreenTarget.EOnGreenTargetHit += heal;

        currentHealth = setMaxHealth;
        maxHealth = setMaxHealth;

        healthBar.SetMaxHealth(setMaxHealth);

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
        if(currentHealth < setMaxHealth) {
            currentHealth += healModifier * baseHeal;
            healthBar.UpdateHealth(currentHealth);
        }
    }
    public void increaseMaxHealth(int health) {
        setMaxHealth += health;
    }
    public void setCurrentHealth(int health) {
        currentHealth = setMaxHealth;
        healthBar.UpdateHealth(currentHealth);
    }
    public static int GetCurrentHealth() {
        return currentHealth;
    }
    public static int GetMaxHealth() {
        return maxHealth;
    }
    private void OnDestroy() {
        PlayerShoot.EOnTargetMiss -= takeDamage;
        Target.EOnTargetDespawn -= takeDamage;
        RedTarget.EOnRedTargetHit -= takeDamage;
        GreenTarget.EOnGreenTargetHit -= heal;
    }
}
