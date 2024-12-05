using UnityEngine;
using System.Collections;

public class GreenTarget : Target
{
    private bool _destroyed;

    public delegate void OnGreenTargetHit();
    public static OnGreenTargetHit EOnGreenTargetHit;

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
            EOnGreenTargetHit?.Invoke();
        }

        UnsubscribeClearingEvents();
    }

}
