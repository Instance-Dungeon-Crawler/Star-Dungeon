using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableReaderEquipement : MonoBehaviour
{
    [SerializeField] private StatsEquipement _statsEquipement;

    [HideInInspector] public int _equipementLife;
    [HideInInspector] public int _equipementMana;
    [HideInInspector] public int _equipementAttackSpeed;
    [HideInInspector] public int _equipementResistance;
    [HideInInspector] public int _equipementPower;
    [HideInInspector] public string _equipementEquipementName;
    [HideInInspector] public string _equipementClassName;

    void Awake()
    {
        _equipementEquipementName = _statsEquipement._equipementName;
        _equipementLife = _statsEquipement._life;
        _equipementMana = _statsEquipement._mana;
        _equipementAttackSpeed = _statsEquipement._attackSpeed;
        _equipementResistance = _statsEquipement._resistance;
        _equipementPower = _statsEquipement._power;
    }
}
