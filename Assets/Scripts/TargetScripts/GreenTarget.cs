using UnityEngine;
using System.Collections;

public class GreenTarget : Target
{
    private bool _destroyed;

    public delegate void OnGreenTargetHit();
    public static OnGreenTargetHit EOnGreenTargetHit;

    void Start()
    {
        _destroyed = true;
        StartCoroutine(WaitForDestroy());
    }

    protected override void DoTargetBehavior()
    {
        _destroyed = false;
    }

    private void OnDestroy() {
        if(_destroyed) {
            EOnGreenTargetHit?.Invoke();
        }
    }

}
