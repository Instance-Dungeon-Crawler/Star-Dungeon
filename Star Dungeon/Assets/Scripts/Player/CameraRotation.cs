using System.Collections;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [Header("Angles")]
    [HideInInspector] public Quaternion _targetAngle;
    private Quaternion _currentAngle;

    [Header("Time")]
    [SerializeField] private float _time;

    [Header("Curve Movements")]
    [SerializeField] AnimationCurve _curve;
    public bool _canRotate = false;
    public IEnumerator RotateCameraLeft()
    {
        _currentAngle = transform.rotation;
        _targetAngle = Quaternion.Euler(0f, (transform.rotation.eulerAngles.y - 90), 0f);
        Debug.Log(transform.rotation.eulerAngles.y);

        float time = 0f;
        while (time < 1)
        {
            _canRotate = false;
            this.transform.rotation = Quaternion.LerpUnclamped(_currentAngle, _targetAngle, time);

            yield return null;
            time += Time.deltaTime / _time;
        }
        _canRotate = true;
        transform.rotation = _targetAngle;

    }

    public IEnumerator RotateCameraRight()
    {
        _currentAngle = transform.rotation;
        _targetAngle = Quaternion.Euler(0f, (transform.rotation.eulerAngles.y + 90), 0f);
        Debug.Log(transform.rotation.eulerAngles.y);

        float time = 0f;
        while (time < 1)
        {
            _canRotate = false;
            this.transform.rotation = Quaternion.LerpUnclamped(_currentAngle, _targetAngle, time);

            yield return null;
            time += Time.deltaTime / _time;
        }
        _canRotate = true;
        transform.rotation = _targetAngle;

    }

    public void RotateRight()
    {
        StartCoroutine(RotateCameraRight());
    }


    public void RotateLeft()
    {
        StartCoroutine(RotateCameraLeft());

    }
}
