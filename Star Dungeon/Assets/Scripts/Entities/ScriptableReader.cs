using UnityEngine;

public class ScriptableReader : MonoBehaviour
{
    [SerializeField] private StatsEntity _statsEntity;

    [HideInInspector] public int _playerLife;
    [HideInInspector] public int _playerMana;
    [HideInInspector] public int _playerAttackSpeed;
    [HideInInspector] public int _playerResistance;
    [HideInInspector] public int _playerPower;
    [HideInInspector] public string _playerPlayerName;
    [HideInInspector] public string _playerClassName;

    void Awake()
    {
        _playerPlayerName = _statsEntity._entityName;
        _playerClassName = _statsEntity._className;
        _playerLife = _statsEntity._life;
        _playerMana = _statsEntity._mana;
        _playerAttackSpeed = _statsEntity._attackSpeed;
        _playerResistance = _statsEntity._resistance;
        _playerPower = _statsEntity._power;
    }
}



