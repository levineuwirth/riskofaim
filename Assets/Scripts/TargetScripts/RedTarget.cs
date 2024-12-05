using UnityEngine;
using System.Collections;

public class RedTarget : Target
{
    public delegate void OnRedTargetHit();
    public static OnRedTargetHit EOnRedTargetHit;
    private bool _destroyed;


    void Start()
    {
        SubscribeClearingEvents();

        _destroyed = true;
        StartCoroutine(GrowOverTime());
        StartCoroutine(WaitForDestroy());
    }

    protected override void DoTargetBehavior()
    {
        _destroyed = false;
    }

    private void OnDestroy() {
        if(_destroyed && !_isClearing) {
            EOnRedTargetHit?.Invoke();
        }

        UnsubscribeClearingEvents();
    }

}
