using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableReader : MonoBehaviour
{
    [SerializeField] private StatePlayer _statePlayer;

    [HideInInspector] public int _playerLife;
    [HideInInspector] public int _playerMana;
    [HideInInspector] public int _playerAttackSpeed;
    [HideInInspector] public int _playerResistance;
    [HideInInspector] public int _playerPower;
    [HideInInspector] public string _playerPlayerName;
    [HideInInspector] public string _playerClassName;

    void Awake()
    {
        _playerPlayerName = _statePlayer._playerName;
        _playerClassName = _statePlayer._className;
        _playerLife = _statePlayer._life;
        _playerMana = _statePlayer._mana;
        _playerAttackSpeed = _statePlayer._attackSpeed;
        _playerResistance = _statePlayer._resistance;
        _playerPower = _statePlayer._power;
    }
}



