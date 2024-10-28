using System;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [field: SerializeField] public float xLookLimit {get; private set;}
    [field: SerializeField] public float yLookLimit {get; private set;}
    [field: SerializeField] public float xLookSpeed {get; private set;}
    [field: SerializeField] public float yLookSpeed {get; private set;}

    private float _xRotation;
    private float _yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        _xRotation += Input.GetAxis("Mouse X") * xLookSpeed;
        _xRotation = Math.Clamp(_xRotation, -xLookLimit, xLookLimit);
        _yRotation += -Input.GetAxis("Mouse Y") * yLookSpeed;
        _yRotation = Math.Clamp(_yRotation, -yLookLimit, yLookLimit);

        transform.rotation = Quaternion.Euler(new Vector3 (_yRotation, _xRotation));
    }
}