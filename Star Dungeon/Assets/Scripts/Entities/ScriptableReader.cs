using UnityEngine;

public class ScriptableReader : MonoBehaviour
{
    [SerializeField] private StatsEntity _statsEntity;

    public float _entityLife;
    [HideInInspector] public float _entityMana;
    [HideInInspector] public float _entityAttackSpeed;
    [HideInInspector] public float _entityResistance;
    [HideInInspector] public float _entityPower;
    [HideInInspector] public string _entityName;
    [HideInInspector] public string _entityClassName;
    [HideInInspector] public int _entityLevel;
    [HideInInspector] public int _entityXP;
    [HideInInspector] public int _entityCooldown;


    void Awake()
    {
        _entityName = _statsEntity._entityName;
        _entityClassName = _statsEntity._className;;
        _entityLife = _statsEntity._life;
        _entityMana = _statsEntity._mana;
        _entityAttackSpeed = _statsEntity._attackSpeed;
        _entityResistance = _statsEntity._resistance;
        _entityPower = _statsEntity._power;
        _entityLevel = _statsEntity._level;
        _entityXP = _statsEntity._XP;
        _entityCooldown = _statsEntity._Cooldown;
    }
}



