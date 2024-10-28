using System;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public float maxCapacity;
    private float currentCapacity;
    private bool _isReloading;
    private float reloadTime;
    private float reloadTimeMultipler;

    void Start()
    {
        reloadTime = 5; // need to playtest where we should start this
        reloadTimeMultipler = 1; //placeholder
        currentCapacity = maxCapacity;
        _isReloading = false;
    }

    void Update()
    {

    }

    bool decrementMagazine(){
        if (currentCapacity < 1 || _isReloading){
            return false; // the shot, i.e. raycasts, should NOT be fired 
        }  
        currentCapacity -= 1;
        return true; // the shot, i.e. raycasts, should be fired
    }

    void reloadMagazine(){
        _isReloading = true;
        // WaitForSeconds(reloadTime);
        currentCapacity = maxCapacity;
        _isReloading = false;
    }
}