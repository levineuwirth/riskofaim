using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public delegate void OnTargetHit();
    public static OnTargetHit EOnTargetHit;
    [field: SerializeField] public AudioSource deathSFX {get; private set;}
    [field: SerializeField] public Camera playerCamera {get; private set;}
    private RaycastHit _raycastHit;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            
            // reduce ammo by 1

            if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out _raycastHit, 100f, LayerMask.GetMask("Target"))) {
                deathSFX.Play();
                Destroy(_raycastHit.transform.gameObject);
                EOnTargetHit?.Invoke();

                // Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * 100.0f, Color.yellow);
            } else {
                // Decrement health logic. For now we just use a backspace placeholder.
            }
        }
    }
}