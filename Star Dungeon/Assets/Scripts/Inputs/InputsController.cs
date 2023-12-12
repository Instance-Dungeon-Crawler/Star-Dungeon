using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerMovement _playerMovements;
    [SerializeField] private CameraRotation _cameraRotation;
    private bool _inventoryIsOpen = false;


    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    public void PlayerMovements(InputAction.CallbackContext context)
    {
        if (context.started && _playerMovements._canMove && _cameraRotation._canRotate)
            _playerController.OnMove();
        else if(context.canceled && _playerMovements._canMove)
            _cameraRotation._canRotate = false;
    }

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

    public void OpenInvent(InputAction.CallbackContext context)
    {
        if (!_inventoryIsOpen)
        {
            if (context.started)
            {
                _inventoryIsOpen = true;
                GameObject.Find("Inventory (Canvas)").transform.Find("Fond Menu").gameObject.SetActive(true);
            }
        }
        else
        {
            if (_inventoryIsOpen)
            {
                if (context.started)
                {
                    _inventoryIsOpen = false;
                    GameObject.Find("Inventory (Canvas)").transform.Find("Fond Menu").gameObject.SetActive(false);
                }
            }
        }

    }



}
