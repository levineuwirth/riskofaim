using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;

    private float decrementFactor;
    private float decrementMultiplier;

    void Start()
    {
        decrementFactor = 5; // placeholder
        decrementMultiplier = 1; //placeholder
    }

    void Update()
    {

    }

    void decrementHealth(){
        maxHealth -= decrementFactor * decrementMultiplier;
        if (maxHealth <= 0) {
            Debug.Log("Player is taking damage");
            // Trigger logic for death / game loss.
        }
    }
}