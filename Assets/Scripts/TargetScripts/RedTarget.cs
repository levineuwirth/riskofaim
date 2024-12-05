using UnityEngine;
using System.Collections;

public class RedTarget : Target
{

    private bool _destroyed;

    public delegate void OnRedTargetHit();
    public static OnRedTargetHit EOnRedTargetHit;

    void Start()
    {
        _destroyed = true;
        StartCoroutine(GrowOverTime());
        StartCoroutine(WaitForDestroy());
    }

    protected override void DoTargetBehavior()
    {
        _destroyed = false;
    }

    private void OnDestroy() {
        if(_destroyed) {
            EOnRedTargetHit?.Invoke();
        }
    }

}
