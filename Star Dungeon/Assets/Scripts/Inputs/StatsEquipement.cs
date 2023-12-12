using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipement", menuName = "Equipement")]
public class StatsEquipement : ScriptableObject
{
    public string _equipementName;

    public int _life;
    public int _mana;
    public int _attackSpeed;
    public int _resistance;
    public int _power;
}
