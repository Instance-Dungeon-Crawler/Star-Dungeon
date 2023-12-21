using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class GodMod : MonoBehaviour
{
    private int _GuerrierHP;
    private int _GuerrierDamage;
    private int _SupportHP;
    private int _SupportDamage;
    private int _VoleurHP;
    private int _VoleurDamage;
    private bool _cntrl = false;
    private bool _d = false;
    private bool _god = false;
    PlayerMovement _playerMovement;
    CameraRotation _cameraRotation;
    public GameObject _player;

    enum E_GameState
    {
        E_GodMode,
        E_NormalMode
    };

    E_GameState GameState = E_GameState.E_NormalMode;

    public bool _controlIsPressed = false;
    public bool _dIsPressed = false;
    public bool _godmodeIsActived = false;

    public static GodMod Instance;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _cameraRotation = GetComponent<CameraRotation>();
    }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.Log("There is two godmode");
            Destroy(this);
            return;
        }
    }

    private void Update()
    {
        Debug.Log("GodMode bool : " + _godmodeIsActived);
        Debug.Log("Guerrier HP : " + _GuerrierHP);
        if (_controlIsPressed && _dIsPressed)
            _godmodeIsActived = true;
        else if(!_controlIsPressed && !_dIsPressed)
            _godmodeIsActived = false;

        if (_godmodeIsActived == true)
        {
            ToggleGodMode();
        }
    }


    public void D(InputAction.CallbackContext context)
    {
        if (context.started && _d == false)
        {
            _d = true;
        }

        else if (context.canceled)
        {

            _d = false;


        }


    }

    public void Cntrl(InputAction.CallbackContext context)
    {
        if (context.started && _cntrl == false)
        {
            _cntrl = true;
        }

        else if (context.canceled)
        {

            _cntrl = false;
        }
    }

    public void ToggleGodMode()
    {
        if (GameState == E_GameState.E_GodMode)
        {
            GameState = E_GameState.E_NormalMode;
        }
        else if (GameState == E_GameState.E_NormalMode)
        {
            GameState = E_GameState.E_GodMode;
        }

        switch (GameState)
        {
            case E_GameState.E_GodMode:
                _GuerrierHP = 100000;
                _GuerrierDamage = 1000000;
                _SupportHP = 100000;
                _SupportDamage = 100000;
                _VoleurHP = 100000;
                _VoleurDamage = 100000;
                _player.GetComponent<PlayerMovement>()._time = 0.1f;
                _player.GetComponent<CameraRotation>()._time = 0.1f;

                break;

            case E_GameState.E_NormalMode:
                _GuerrierHP = 150;
                _GuerrierDamage = 75;
                _SupportHP = 100;
                _SupportDamage = 50;
                _VoleurHP = 75;
                _VoleurDamage = 100;
                _player.GetComponent<PlayerMovement>()._time = 0.5f;
                _player.GetComponent<CameraRotation>()._time = 0.5f;
                break;
            default:
                break;
        }
    }
}
