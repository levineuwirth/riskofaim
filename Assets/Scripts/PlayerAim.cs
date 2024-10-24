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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _xRotation += Input.GetAxis("Mouse Y") * xLookSpeed;
        _xRotation = Math.Clamp(_xRotation, -xLookLimit, xLookLimit);
        _yRotation += Input.GetAxis("Mouse X") * yLookSpeed;
        _yRotation = Math.Clamp(_yRotation, -yLookLimit, yLookLimit);

        transform.rotation = Quaternion.Euler(new Vector3 (_xRotation, _yRotation, 0));
    }
}
