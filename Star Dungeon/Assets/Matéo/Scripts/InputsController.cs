using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{


    PlayerInput _playerInput;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Cameramovements _cameraMovements;
    public bool RotationRight = false;


    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    public void PlayerMovements(InputAction.CallbackContext context)
    {
        Vector3 vector3 = context.ReadValue<Vector3>();
        if (context.performed)
        
            _playerController.OnMove(vector3);

    }

    public void NegativeRotation(InputAction.CallbackContext context)
    {
        if (context.performed && _cameraMovements._canRotate)
        {
            _cameraMovements.Rotate();
            _cameraMovements.targetAngle = Quaternion.Euler(0, _cameraMovements.transform.rotation.eulerAngles.y - 90, 0f);
        }
    }

    public void PositiveRotation(InputAction.CallbackContext context)
    {
        if (context.performed && _cameraMovements._canRotate)
        {
            _cameraMovements.Rotate();
            _cameraMovements.targetAngle = Quaternion.Euler(0, _cameraMovements.transform.rotation.eulerAngles.y + 90, 0f);
        }
    }



}
