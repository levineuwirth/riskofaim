using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GunAnimation : MonoBehaviour {
    private Animator _shootAnimator;
    public static GunAnimation Instance;
    [field: SerializeField] public GameObject gunParticles;
    private float forwardOffset = 0.5f;
    private float upwardOffset = 0.2f;
    private Vector3 spawnPosition;
    private void Awake() {
        Instance = this;
    }
    private void Start() {
        PlayerShoot.EOnPlayerShoot += PlayShoot;

        _shootAnimator = gameObject.GetComponent<Animator>();
    }
    private void PlayShoot() {
       _shootAnimator.SetTrigger("Shoot");
        spawnPosition = transform.position + transform.forward * forwardOffset + transform.up * upwardOffset;
        Instantiate(gunParticles, spawnPosition, Quaternion.identity);

    }
    private void OnDestroy() {
        PlayerShoot.EOnPlayerShoot -= PlayShoot;
    }
}