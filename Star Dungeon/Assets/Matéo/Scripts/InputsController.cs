using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{
    [SerializeField] PlayerMovement _playerMovement;
    PlayerInput _playerInput;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Cameramovements _cameraMovements;


    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    public void PlayerMovements(InputAction.CallbackContext context)
    {
        if (context.started && _playerMovement._canMove && _cameraMovements._canRotate)
        {

            _playerController.OnMove();

            Rigidbody rb = GetComponent<Rigidbody>();

            rb.constraints = RigidbodyConstraints.FreezeRotationX;

        }
        if (context.canceled && _playerMovement._canMove)
        {
            _playerMovement._canRotate = false;

        }
    }

    public void NegativeRotation(InputAction.CallbackContext context)
    {
        if (context.performed && _cameraMovements._canRotate && _playerMovement._canMove)
        {
            _cameraMovements.Rotate();
            _cameraMovements.targetAngle = Quaternion.Euler(0, _cameraMovements.transform.rotation.eulerAngles.y - 90, 0f);
            _playerMovement._canMove = false;

            Rigidbody rb = GetComponent<Rigidbody>();


            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        }

        else if (context.canceled)
        {
            _playerMovement._canMove = true;

        }
    }

    public void PositiveRotation(InputAction.CallbackContext context)
    {
        if (context.performed && _cameraMovements._canRotate && _playerMovement._canMove)
        {

            _cameraMovements.Rotate();
            _cameraMovements.targetAngle = Quaternion.Euler(0, _cameraMovements.transform.rotation.eulerAngles.y + 90, 0f);
            _playerMovement._canMove = false;

            Rigidbody rb = GetComponent<Rigidbody>();


            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        }
        else if (context.canceled)
        {
            _playerMovement._canMove = true;

        }

    }



}
