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
    public GameObject controls;
    public GameObject pause;
    public GameObject game;

    private bool WallcheckFront()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(_player.position.x, _player.position.y + 2, _player.position.z), _player.forward, out hit, 3f))
        {
            if (hit.collider.tag == "Wall")
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        if (Physics.Raycast(new Vector3(_player.position.x, _player.position.y + 2, _player.position.z), _player.forward, out hit, 7f))
        {
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
        if (Physics.Raycast(new Vector3(_player.position.x, _player.position.y + 2, _player.position.z), -_player.forward, out hit, 3f))
        {
            if (hit.collider.tag == "Wall")
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        else if (Physics.Raycast(new Vector3(_player.position.x, _player.position.y + 2, _player.position.z), -_player.forward, out hit, 5f))
        {
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
        if (!WallcheckBack() && context.started && _playerMovements._canMove)
        { 
            _playerController.OnMoveBack(); 
            _cameraRotation._canRotate = false; 
            _playerMovements._canMove = false;
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed && controls.activeSelf == false && game.activeSelf == false)
        {
            pause.SetActive(true);
            Time.timeScale = 0;
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

    public void GodModeControl(InputAction.CallbackContext context)
    {
        if(context.performed && !GodMod.Instance._controlIsPressed)
            GodMod.Instance._controlIsPressed = true;
        else if(context.performed && GodMod.Instance._controlIsPressed)
            GodMod.Instance._controlIsPressed = false;
    }

    public void GodModeD(InputAction.CallbackContext context)
    {
        if (context.performed && !GodMod.Instance._dIsPressed)
            GodMod.Instance._dIsPressed = true;
        else if (context.performed && GodMod.Instance._dIsPressed)
            GodMod.Instance._dIsPressed = false;
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

