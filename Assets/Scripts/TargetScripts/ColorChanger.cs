using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour
{
    [field: SerializeField] public Gradient albedoTint;
    [field: SerializeField] public float duration = 2.5f;

    private MaterialPropertyBlock propertyBlock;
    private MeshRenderer meshRenderer;

    private float currentTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        propertyBlock = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Mathf.Repeat(currentTime + Time.deltaTime, duration);
        var newColor = albedoTint.Evaluate(currentTime / duration);
        propertyBlock.SetColor("_BaseColor", newColor);
        meshRenderer.SetPropertyBlock(propertyBlock);
    }
}
