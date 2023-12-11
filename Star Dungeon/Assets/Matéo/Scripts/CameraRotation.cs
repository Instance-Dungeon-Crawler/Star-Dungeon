using System.Collections;
using UnityEngine;

public class Cameramovements : MonoBehaviour
{
    public Quaternion targetAngle;
    public Quaternion _currentAngle;
    [SerializeField] private float _time;
    [SerializeField] AnimationCurve _curve;
    public bool _canRotate = true;
   

    public IEnumerator RotateCameraLeft()
    {
        _currentAngle = transform.rotation;
        targetAngle = Quaternion.Euler(0f, (transform.rotation.eulerAngles.y - 90), 0f);
      
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

    public void Rotate()
    {
        StartCoroutine(RotateCameraLeft());
    }
}


