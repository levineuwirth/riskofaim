using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    [field: SerializeField] float targetHealth;
    [field: SerializeField] float targetLifetime;
    protected float growthDuration = 0.1f;

    public delegate void OnTargetDespawn();
    public static OnTargetDespawn EOnTargetDespawn;

    protected bool _isClearing;

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
    protected void Clearing() {
        _isClearing = true;
        Debug.Log("clearing");
    }
    protected void NotClearing() {
        _isClearing = false;
        Debug.Log("not clearing");
    }
    protected void SubscribeClearingEvents() {
        TargetSpawner.EOnClearTargetsStart += Clearing;
        TargetSpawner.EOnClearTargetsEnd += NotClearing;
    }
    protected void UnsubscribeClearingEvents() { 
        TargetSpawner.EOnClearTargetsStart -= Clearing;
        TargetSpawner.EOnClearTargetsEnd -= NotClearing;
    }
    protected IEnumerator GrowOverTime()
    {
        Vector3 initialScale = new Vector3(0.1f, 0.1f, 0.1f);
        Vector3 targetScale = Vector3.one;
        float elapsedTime = 0f;

        while (elapsedTime < growthDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / growthDuration;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, progress);
            yield return null;
        }
        transform.localScale = targetScale;
    }
}
