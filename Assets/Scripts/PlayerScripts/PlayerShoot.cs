using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public delegate void OnTargetHit();
    public delegate void OnTargetMiss();
    public delegate void OnPlayerShoot();
    public static OnTargetHit EOnTargetHit;
    public static OnTargetMiss EOnTargetMiss;
    public static OnPlayerShoot EOnPlayerShoot;
    [field: SerializeField] public AudioSource deathSFX {get; private set;}
    [field: SerializeField] public AudioSource shootSFX {get; private set;}
    [field: SerializeField] public Camera playerCamera {get; private set;}
    [field: SerializeField] public GameObject deathParticles;
    private RaycastHit _raycastHit;
    private static bool _canShoot;

    private void Start() {
        Countdown.EActivateRound += EnableShooting;
        Timer.EOnRoundEnd += DisableShooting;

        DisableShooting();
    }

    private void Update() {
        if(!PauseManager.isPaused) {
            if(_canShoot) {
                if(Input.GetKeyDown(PlayerController.Instance.primaryFire)) {

                    EOnPlayerShoot?.Invoke();
                    shootSFX.Play();

                    if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out _raycastHit, 100f, LayerMask.GetMask("Target"))) {
                        deathSFX.Play();
                        Instantiate(deathParticles, _raycastHit.transform.position, Quaternion.identity);
                        Destroy(_raycastHit.transform.gameObject);
                        EOnTargetHit?.Invoke();
                    } else {
                        EOnTargetMiss?.Invoke();
                    }
                }
            }
        }
    }
    private void EnableShooting() {
        _canShoot = true;
    }
    private void DisableShooting() {
        _canShoot = false;
    }
    public static bool GetCanShoot() {
        return _canShoot;
    }
    private void OnDestroy() {
        Countdown.EActivateRound -= EnableShooting;
        Timer.EOnRoundEnd -= DisableShooting;
    }
}
