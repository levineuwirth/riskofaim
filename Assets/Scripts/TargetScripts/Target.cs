using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    [field: SerializeField] float targetHealth;
    [field: SerializeField] float targetLifetime;

    protected IEnumerator WaitForDestroy()
    {
        float animWait = targetLifetime;
        yield return new WaitForSeconds(animWait);
        Destroy(gameObject);
    }
}
