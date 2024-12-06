using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GunAnimation : MonoBehaviour {
    private Animator _shootAnimator;
    public static GunAnimation Instance;
    [field: SerializeField] public GameObject gunParticles;
    private float forwardOffset = 1.0f;
    private float upwardOffset = 0.2f;
    private Vector3 spawnPosition;
    private GameObject particleInstance;
    private ParticleSystem gunParticleSystem;
    private Transform particleTransform;


    private void Awake() {
        Instance = this;
    }

    private void Start() {
        PlayerShoot.EOnPlayerShoot += PlayShoot;
        _shootAnimator = gameObject.GetComponent<Animator>();


        particleInstance = Instantiate(gunParticles, transform);
        particleInstance.transform.localPosition = new Vector3(0, upwardOffset, forwardOffset);
        gunParticleSystem = particleInstance.GetComponent<ParticleSystem>();
        particleTransform = particleInstance.transform;
        Debug.Log("1");
    }

    private void PlayShoot() {
       _shootAnimator.SetTrigger("Shoot");

        particleInstance.transform.localPosition = new Vector3(0, upwardOffset, forwardOffset);
        Debug.Log("2");
        Quaternion adjustedRotation = transform.rotation;
        adjustedRotation *= Quaternion.Euler(12f, 17f, 0f);
        particleTransform.rotation = adjustedRotation;
        Debug.Log("3");
        if (gunParticleSystem != null)
        {
            gunParticleSystem.Play();
            Debug.Log("4");
        }
    }

    private void OnDestroy() {
        PlayerShoot.EOnPlayerShoot -= PlayShoot;
    }
}