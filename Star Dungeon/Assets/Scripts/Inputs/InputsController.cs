using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerMovement _playerMovements;
    [SerializeField] private CameraRotation _cameraRotation;
    private bool _inventoryIsOpen = false;

    public void PlayerForward(InputAction.CallbackContext context)
    {
        if (context.started && _playerMovements._canMove)
        {
            _playerController.OnMoveForward();
            _cameraRotation._canRotate = false;
            _playerMovements._canMove = false;
        }
    }

    public void PlayerBack(InputAction.CallbackContext context)
    {
        if (context.started && _playerMovements._canMove)
        {
            _playerController.OnMoveBack();
            _cameraRotation._canRotate = false;
            _playerMovements._canMove = false;
        }
    }

    public void NegativeRotation(InputAction.CallbackContext context)
    {
        if (context.performed && _cameraRotation._canRotate)
        {
            _cameraRotation.Rotate();
            _cameraRotation._targetAngle = Quaternion.Euler(0, _cameraRotation.transform.rotation.eulerAngles.y - 90, 0f);
            _playerMovements._canMove = false;
        }
    }

    public void PositiveRotation(InputAction.CallbackContext context)
    {
        if (context.performed && _cameraRotation._canRotate)
        {
            _cameraRotation.Rotate();
            _cameraRotation._targetAngle = Quaternion.Euler(0, _cameraRotation.transform.rotation.eulerAngles.y + 90, 0f);
            _playerMovements._canMove = false;
        }
    }

    public void OpenInvent(InputAction.CallbackContext context)
    {
        if (!_inventoryIsOpen)
        {
            if (context.started)
            {
                _inventoryIsOpen = true;
                GameObject.Find("Inventory (Canvas)").transform.Find("Inventory").gameObject.SetActive(true);
                GameObject.Find("HUD").transform.Find("Inventory").gameObject.SetActive(false);
            }
        }
        else
        {
            if (_inventoryIsOpen)
            {
                if (context.started)
                {
                    _inventoryIsOpen = false;
                    GameObject.Find("Inventory (Canvas)").transform.Find("Inventory").gameObject.SetActive(false);
                    GameObject.Find("HUD").transform.Find("Inventory").gameObject.SetActive(true);
                }
            }
        }

    }



}
