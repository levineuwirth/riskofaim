using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour
{
    [field: SerializeField] public Gradient albedoTint;
    [field: SerializeField] public float duration = 2.5f;

    private MaterialPropertyBlock propertyBlock;
    private MeshRenderer meshRenderer;

    private float currentTime = 0f;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        propertyBlock = new MaterialPropertyBlock();
    }

    void Update()
    {
        currentTime = Mathf.Repeat(currentTime + Time.deltaTime, duration);
        var newColor = albedoTint.Evaluate(currentTime / duration);
        propertyBlock.SetColor("_BaseColor", newColor);
        meshRenderer.SetPropertyBlock(propertyBlock);
    }
}
