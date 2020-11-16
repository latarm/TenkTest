using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampsRotate : MonoBehaviour
{
    public float RotateSpeed = 0.15f;
    public GameObject GameController;
    public Joystick Controller;

    private Vector3 _rampsRotateDirection;
    private float _horizontal, _vertical;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        RampRotate(RotateSpeed);
    }

    void RampRotate(float speed = 1)
    {
        _horizontal = Controller.Horizontal * speed;
        _vertical = Controller.Vertical * speed;

        if (_horizontal != 0 || _vertical != 0)
        {
            _rampsRotateDirection = -GameController.transform.forward * _horizontal + GameController.transform.right * _vertical;
            transform.Rotate(_rampsRotateDirection.x, 0, _rampsRotateDirection.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mainCamera.transform.parent = transform;
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _mainCamera.transform.parent = null;
        other.transform.parent = null;
    }
}
