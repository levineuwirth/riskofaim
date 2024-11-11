using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    [field: SerializeField] LayerMask targetLayerMask;
    private bool targetFound = false;
    void Start()
    {
        targetLayerMask = LayerMask.GetMask("TargetLayer");
        Vector3 center = gameObject.transform.position;
        float radius = 1;

        Collider[] hitColliders = Physics.OverlapSphere(center, radius, targetLayerMask);
        Debug.Log(hitColliders.Length);
        if(hitColliders.Length != 0)
        {
            targetFound = true;
        }
        else
        {
            targetFound = false;
        }

        TargetSpawner.Instance.SetTargetFound(targetFound);

        Destroy(gameObject);
    }

}
