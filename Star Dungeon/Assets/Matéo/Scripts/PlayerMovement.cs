using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float _movespeed;
    private Vector3 _moveDirection;

    private void FixedUpdate()
    {
        PlayerMovements();
    }

    public void Move(Vector3 _vector3)
    {
        _moveDirection = _vector3;
    }

    public void PlayerMovements()
    {
        rb.velocity = _moveDirection * _movespeed;
    }


}
