using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    [field: SerializeField] public Material[] frames {get; private set;}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WaitForDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitForDestroy()
    {
        float animWait = 2.5f;
        yield return new WaitForSeconds(animWait);
        Destroy(gameObject);
    }

    private void OnDestroy() {
        
    }
}
