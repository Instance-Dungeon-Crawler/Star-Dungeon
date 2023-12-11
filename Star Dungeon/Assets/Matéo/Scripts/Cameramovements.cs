using System.Collections;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Quaternion targetAngle;
    public Quaternion _currentAngle;
    [SerializeField] private float _time;
    [SerializeField] AnimationCurve _curve;
    public bool _canRotate = false;
    private void Start()
    {

    }
    private void FixedUpdate()
    {

    }
    public IEnumerator RotateCameraLeft()
    {
        _currentAngle = transform.rotation;
        targetAngle = Quaternion.Euler(0f, (transform.rotation.eulerAngles.y - 90), 0f);
        Debug.Log(transform.rotation.eulerAngles.y);

        float time = 0f;
        while (time < 1)
        {
            _canRotate = false;
            this.transform.rotation = Quaternion.LerpUnclamped(_currentAngle, targetAngle, time);

            yield return null;
            time += Time.deltaTime / _time;
        }
        _canRotate = true;
        transform.rotation = targetAngle;

    }

    public IEnumerator RotateCameraRight()
    {
        _currentAngle = transform.rotation;
        targetAngle = Quaternion.Euler(0f, (transform.rotation.eulerAngles.y + 90), 0f);
        Debug.Log(transform.rotation.eulerAngles.y);

        float time = 0f;
        while (time < 1)
        {
            _canRotate = false;
            this.transform.rotation = Quaternion.LerpUnclamped(_currentAngle, targetAngle, time);

            yield return null;
            time += Time.deltaTime / _time;
        }
        _canRotate = true;
        transform.rotation = targetAngle;

    }

    public void RotateRight()
    {
        StartCoroutine(RotateCameraRight());
    }


    public void Rotateleft()
    {
        StartCoroutine(RotateCameraLeft());

    }

    
}