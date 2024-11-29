using UnityEngine;
using System.Collections;

public class BlueTarget : Target
{

    [field: SerializeField] public GameObject ReinforcedTargetPrefab {get; private set;}

    private bool _destroyed;

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
            Instantiate(ReinforcedTargetPrefab, gameObject.transform.position, Quaternion.identity);
        }
        else {
            EOnTargetDespawn?.Invoke();
        }
    }

}
