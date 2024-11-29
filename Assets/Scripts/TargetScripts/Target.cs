using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    [field: SerializeField] float targetHealth;
    [field: SerializeField] float targetLifetime;

    public delegate void OnTargetDespawn();
    public static OnTargetDespawn EOnTargetDespawn;

    protected IEnumerator WaitForDestroy()
    {
        float animWait = targetLifetime;
        yield return new WaitForSeconds(animWait);

        DoTargetBehavior();
        Destroy(gameObject);
    }

    protected virtual void DoTargetBehavior() {
        EOnTargetDespawn?.Invoke();
    }
}
