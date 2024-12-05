using UnityEngine;
using System.Collections;

public class BlueTarget : Target
{

    [field: SerializeField] public GameObject ReinforcedTargetPrefab {get; private set;}

    private bool _destroyed;

    void Start()
    {
        SubscribeClearingEvents();

        _destroyed = true;
        _isClearing = false;

        StartCoroutine(GrowOverTime());
        StartCoroutine(WaitForDestroy());
    }

    protected override void DoTargetBehavior()
    {
        _destroyed = false;
    }
    private void OnDestroy() {
        if(_destroyed && !_isClearing) {
            Instantiate(ReinforcedTargetPrefab, gameObject.transform.position, Quaternion.identity);
        }
        else if(!_destroyed && !_isClearing){
            EOnTargetDespawn?.Invoke();
        }

        UnsubscribeClearingEvents();
    }

}
