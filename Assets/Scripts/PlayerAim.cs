using System;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [field: SerializeField] public float xLookLimit {get; private set;}
    [field: SerializeField] public float yLookLimit {get; private set;}
    [field: SerializeField] public float xLookSpeed {get; private set;}
    [field: SerializeField] public float yLookSpeed {get; private set;}
    [field: SerializeField] public Camera playerCamera {get; private set;}

    private float _xRotation;
    private float _yRotation;
    private RaycastHit _raycastHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        _xRotation += Input.GetAxis("Mouse X") * xLookSpeed;
        _xRotation = Math.Clamp(_xRotation, -xLookLimit, xLookLimit);
        _yRotation += -Input.GetAxis("Mouse Y") * yLookSpeed;
        _yRotation = Math.Clamp(_yRotation, -yLookLimit, yLookLimit);

        transform.rotation = Quaternion.Euler(new Vector3 (_yRotation, _xRotation));

        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out _raycastHit, 100f)) {
                Debug.Log("raycast hit");
                // Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * 100.0f, Color.yellow);
            }
        }
    }
}
