using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerMovement _playerMovements;
    [SerializeField] private CameraRotation _cameraRotation;
    [SerializeField] private Transform _player;
    private bool _inventoryIsOpen = false;

    private bool WallcheckFront()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(_player.position.x, _player.position.y + 2, _player.position.z), _player.forward, out hit, 2.5f))
        {
            if (hit.collider.name == "Wall")
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        
        Debug.Log("ok");
        if (Physics.Raycast(new Vector3(_player.position.x, _player.position.y + 2, _player.position.z), _player.forward, out hit, 7f))
        {
            Debug.Log(hit.collider.name);
            if(hit.collider.name == "GameObject")
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        return (false);
    }

    private void Update()
    {
        Debug.DrawRay(new Vector3(_player.position.x, _player.position.y + 2, _player.position.z), _player.forward*7f, Color.red);
    }

    private bool WallcheckBack()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(_player.position.x, _player.position.y + 2, _player.position.z), _player.forward, out hit, 2.5f))
        {
            if (hit.collider.name == "Wall")
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        else if (Physics.Raycast(new Vector3(_player.position.x, _player.position.y + 2, _player.position.z), _player.forward, out hit, 5f))
        {
            if (hit.collider.name == "Door" || hit.collider.name == "CloseDoor")
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        return (false);
    }

    public void PlayerForward(InputAction.CallbackContext context)
    {
        if (!WallcheckFront() && context.started && _playerMovements._canMove)
        {
            _playerController.OnMoveForward();
            _cameraRotation._canRotate = false;
            _playerMovements._canMove = false;   
        }
    }

    public void PlayerBack(InputAction.CallbackContext context)
    {
        if (context.started && _playerMovements._canMove && !WallcheckBack())
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

