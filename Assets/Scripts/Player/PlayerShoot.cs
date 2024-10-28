using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    [field: SerializeField] public Camera playerCamera {get; private set;}
    private RaycastHit _raycastHit;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out _raycastHit, 100f, LayerMask.GetMask("Default"))) {
                Debug.Log("raycast hit");

                Destroy(_raycastHit.transform.gameObject);

                // Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * 100.0f, Color.yellow);
            }
        }
    }
}