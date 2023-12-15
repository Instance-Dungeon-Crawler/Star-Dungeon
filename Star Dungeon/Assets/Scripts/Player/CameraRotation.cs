using System;
using System.Collections;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    [Header("Angles")]
    [HideInInspector] public Quaternion _targetAngle;
    private Quaternion _currentAngle;

    [Header("Time")]
    public float _time;

    [Header("Curve Movements")]
    [SerializeField] AnimationCurve _curve;
    public bool _canRotate = true;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public IEnumerator RotateCameraLeft()
    {
        _currentAngle = transform.rotation;
        _targetAngle = Quaternion.Euler(0f, (transform.rotation.eulerAngles.y - 90), 0f);
   
        float time = 0f;
        while (time < 1)
        {
            _canRotate = false;
            this.transform.rotation = Quaternion.LerpUnclamped(_currentAngle, _targetAngle, time);

            yield return null;
            time += Time.deltaTime / _time;
        }
        _canRotate = true;
        _playerMovement._canMove = true;
        transform.rotation = _targetAngle;
    }

    public void Rotate()
    {
        StartCoroutine(RotateCameraLeft());
    }
}
