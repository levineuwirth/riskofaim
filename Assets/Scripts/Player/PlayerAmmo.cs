using System;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    [field: SerializeField] public int nonConsumeChance {get; private set;}
    [field: SerializeField] public float reloadTime {get; private set;}
    [field: SerializeField] public float reloadTimeMultiplier {get; private set;}
    
    public float maxCapacity;
    private float currentCapacity;
    private bool _isReloading;
    
    void Start()
    {
        reloadTime = 5; // need to playtest where we should start this
        reloadTimeMultiplier = 1; //placeholder
        currentCapacity = maxCapacity;
        _isReloading = false;
	nonConsumeChance = 0;
    }

    void Update()
    {

    }

    bool decrementMagazine(){
        if (currentCapacity < 1 || _isReloading){
            return false; // the shot, i.e. raycasts, should NOT be fired 
        }
	// roll for the non-consume chance.
	System.Random rnd = new System.Random();
	int roll = rnd.Next(1, 101-nonConsumeChance);
	if (roll != 1){
		currentCapacity -= 1;
	    }
        return true; // the shot, i.e. raycasts, should be fired
    }

    void reloadMagazine(){
        _isReloading = true;
        // WaitForSeconds(reloadTime);
        currentCapacity = maxCapacity;
        _isReloading = false;
    }
}
