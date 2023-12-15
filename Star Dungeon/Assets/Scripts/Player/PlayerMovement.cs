using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CameraRotation _cameraRotation;
    public float _moveSpeed;
    public Vector3 _targetPos;
    [SerializeField] private float _time;
    public bool _canMove = true;

    private void Start()
    {
        _cameraRotation = GetComponent<CameraRotation>();
    }

    public IEnumerator PlayerMovements()
    {

        float time = 0f;
        Vector3 Startposition = transform.position;
        _targetPos = (transform.position + transform.forward * _moveSpeed);

        while (time < 1)
        {
            _canMove = false;
            this.transform.position = Vector3.LerpUnclamped(Startposition, _targetPos, time);

            yield return null;
            time += Time.deltaTime / _time;
        }
        transform.position = _targetPos;
        _cameraRotation._canRotate = true;
        _canMove = true;
        Debug.Log("Fin du mouvement");
    }

    public void Movements()
    {
        StartCoroutine(PlayerMovements());
    }
}
