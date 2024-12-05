using System;
using System.Data;
using TMPro;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    [field: SerializeField] public int nonConsumeChance {get; private set;}
    [field: SerializeField] public float reloadTime {get; private set;}
    [field: SerializeField] public float reloadTimeMultiplier {get; private set;}
    [field: SerializeField] public int setMaxCapacity {get; private set;}
    private static int _maxCapacity;
    private static int _currentCapacity;
    private bool _isReloading;
    
    void Start()
    {
        PlayerShoot.EOnPlayerShoot += DecrementMagazine;
        _maxCapacity = setMaxCapacity;

        reloadTime = 5; // need to playtest where we should start this
        reloadTimeMultiplier = 1; //placeholder

        _currentCapacity = _maxCapacity;
        _isReloading = false;
	    nonConsumeChance = 0;
    }

    void DecrementMagazine(){
        if(CanShoot()) {
            if(ConsumeAmmo()) {
                _currentCapacity -= 1;
            }
        }
    }

    void ReloadMagazine(){
        _isReloading = true;
        // WaitForSeconds(reloadTime);
        _currentCapacity = _maxCapacity;
        _isReloading = false;
    }

    bool ConsumeAmmo() {
        System.Random rnd = new System.Random();
        int roll = rnd.Next(1, 101 - nonConsumeChance);
        if(roll == 1) {
            return false;
        }
        else {
            return true;
        }
    }

    bool CanShoot() {
        return !(_currentCapacity < 1 || _isReloading);
    }

    public static int GetCurrentAmmo() {
        return _currentCapacity;
    }
    public static int GetMaxAmmo() {
        return _maxCapacity;
    }
    private void OnDestroy() {
        PlayerShoot.EOnPlayerShoot -= DecrementMagazine;
    }
}
