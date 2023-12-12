using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _moveSpeed;
    public Vector3 _targetPos;
    [SerializeField] private float _time;
    public bool _canMove = true;
    public bool _canRotate = true;

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
        _canMove = true;
    }

    public void Movements()
    {
        StartCoroutine(PlayerMovements());
    }
}
