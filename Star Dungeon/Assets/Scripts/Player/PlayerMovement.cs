using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CameraRotation _cameraRotation;
    public int _distance;
    public Vector3 _targetPos;
    [SerializeField] public float _time;
    public bool _canMove = true;
    private Animator _animator;
    public AudioSource _audioSource;

    private void Start()
    {
        _cameraRotation = GetComponent<CameraRotation>();
        _animator = GetComponentInChildren<Animator>();
        
    }

    public IEnumerator PlayerForward()
    {
        _animator.SetTrigger("Camera");
        float time = 0f;
        Vector3 startposition = transform.position;
        _targetPos = (transform.position + transform.forward * _distance);
        //_animator.SetTrigger("Camera");
        while (time < 1) 
        {
            Debug.Log(_time);
            _canMove = false;
            this.transform.position = Vector3.LerpUnclamped(startposition, _targetPos, time);
            yield return null;
            time  += Time.deltaTime / _time;

        }
        transform.position = _targetPos;
        _cameraRotation._canRotate = true;
        _canMove = true;
        ResetPos();
    }

    
    public IEnumerator PlayerBack()
    {
        float time = 0f;
        Vector3 startposition = transform.position;
        _targetPos = (transform.position - transform.forward * _distance);
        while (time < 1)
        {
            _canMove = false;
            this.transform.position = Vector3.LerpUnclamped(startposition, _targetPos, time);

            yield return null;
            time += Time.deltaTime / _time;

        }
        transform.position = _targetPos;
        _cameraRotation._canRotate = true;
        _canMove = true;
        ResetPos();
    }
    void ResetPos()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            if (hit.collider.tag == "Ground")
            {
                transform.position =
                    new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
            }
        }
    }

    public void Forward()
    {

        StartCoroutine(PlayerForward());
    }

    public void Back()
    {

        StartCoroutine(PlayerBack());
    }
}
