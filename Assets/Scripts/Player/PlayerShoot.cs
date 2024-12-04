using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public delegate void OnTargetHit();
    public delegate void OnTargetMiss();
    public delegate void OnPlayerShoot();
    public static OnTargetHit EOnTargetHit;
    public static OnTargetMiss EOnTargetMiss;
    public static OnPlayerShoot EOnPlayerShoot;
    [field: SerializeField] public AudioSource deathSFX {get; private set;}
    [field: SerializeField] public Camera playerCamera {get; private set;}
    private RaycastHit _raycastHit;

    private void Update() {
        if(!PauseManager.isPaused) {
            if(Input.GetKeyDown(PlayerController.Instance.primaryFire)) {
                if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out _raycastHit, 100f, LayerMask.GetMask("Target"))) {
                    deathSFX.Play();
                    Destroy(_raycastHit.transform.gameObject);
                    EOnTargetHit?.Invoke();
                } else {
                    EOnTargetMiss?.Invoke();
                }
            }
        }
    }
}
