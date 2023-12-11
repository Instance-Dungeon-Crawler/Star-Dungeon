using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{
    private PlayerInput _playerInput;
    //[SerializeField] private PlayerController _playerController;
    [SerializeField] private CameraRotation _cameraRotation;


    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    //public void PlayerMovements(InputAction.CallbackContext context)
    //{
    //    Vector3 vector3 = context.ReadValue<Vector3>();
    //    if (context.performed)
        
    //        _playerController.OnMove(vector3);
    //}

    public void NegativeRotation(InputAction.CallbackContext context)
    {
        if (context.performed && _cameraRotation._canRotate)
        {
            _cameraRotation.RotateLeft();
            _cameraRotation._targetAngle = Quaternion.Euler(0, _cameraRotation.transform.rotation.eulerAngles.y - 90, 0f);
        }
        Debug.Log("test");
    }

    public void PositiveRotation(InputAction.CallbackContext context)
    {
        if (context.performed && _cameraRotation._canRotate)
        {
            _cameraRotation.RotateRight();
            _cameraRotation._targetAngle = Quaternion.Euler(0, _cameraRotation.transform.rotation.eulerAngles.y + 90, 0f);
        }
        Debug.Log("test");
    }



}
