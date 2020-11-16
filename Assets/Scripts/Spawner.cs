using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject BallPrefab;
    public Transform RespawnPoint;
    public float Smooth=0.025f;
    public Vector3 BaseCameraOffset;

    private GameObject _ball;
    private Vector3 _baseCameraRotation;
    private Transform _targetTransform;
    private Camera _mainCamera;

    void Start()
    {
        if(_ball==null)
        {
            _ball = Instantiate(BallPrefab, transform.position, Quaternion.identity);
            _ball.name = "Ball";
        }

        SetupCamera();

        Quaternion quaternion = _mainCamera.transform.rotation;
        transform.rotation = Quaternion.Euler(0, quaternion.eulerAngles.y, 0);
    }
 
    private void LateUpdate()
    {
        //_mainCamera.transform.position = _targetTransform.position + _baseCameraOffset;
        _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, _targetTransform.position + BaseCameraOffset, Smooth);
        _mainCamera.transform.LookAt(_targetTransform);
    }

    private void SetupCamera()
    {
        _mainCamera = Camera.main;

        _targetTransform = _ball.transform;
        BaseCameraOffset = _mainCamera.transform.position - _targetTransform.position;
        _baseCameraRotation = _mainCamera.transform.rotation.eulerAngles;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
