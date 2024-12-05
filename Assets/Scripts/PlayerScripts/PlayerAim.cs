using System;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [field: SerializeField] public float yLookLimit {get; private set;}
    [field: SerializeField] public float xLookSpeed {get; private set;}
    [field: SerializeField] public float yLookSpeed {get; private set;}

    private float _xRotation;
    private float _yRotation;

    private void Start() {
        Countdown.EActivateRound += ResetCursorPosition;
    }
    void Update() {
        xLookSpeed = PlayerPrefs.GetFloat("currentSensitivityX");
        yLookSpeed = PlayerPrefs.GetFloat("currentSensitivityY");

        if(!PauseManager.isPaused) {
            if(PlayerShoot.GetCanShoot()) {
                LockCursor();

                _xRotation += Input.GetAxis("Mouse X") * xLookSpeed;
                _xRotation = _xRotation % 360;
                _yRotation += -Input.GetAxis("Mouse Y") * yLookSpeed;
                _yRotation = Mathf.Clamp(_yRotation, -yLookLimit, yLookLimit);

                transform.rotation = Quaternion.Euler(new Vector3 (_yRotation, _xRotation));
            }
        }
        else {
            UnlockCursor();
        }
        
    }
    private void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void UnlockCursor() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void ResetCursorPosition() {
        float currentRotationZ = transform.rotation.z;
        transform.rotation = Quaternion.Euler(0f, 0f, currentRotationZ);
    }
    private void OnDestroy() {
        Countdown.EActivateRound -= ResetCursorPosition;
    }
}
