using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothSpeed = 0.20f;
    [SerializeField] private float _sensitivity = 150.0f;

    private float _currentX = 0.0f;
    private float _currentY = 0.0f;

    private void FixedUpdate()
    {
        if (_target == null)
            return;

        _currentX += Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        _currentY -= Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        Quaternion rotation = Quaternion.Euler(_currentY, _currentX, 0);
        Vector3 desiredPosition = _target.position + rotation * _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);

        transform.position = smoothedPosition;

        transform.LookAt(_target);
    }
}
