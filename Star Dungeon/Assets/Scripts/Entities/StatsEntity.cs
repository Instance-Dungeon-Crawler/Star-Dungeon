using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity")]
public class StatsEntity : ScriptableObject
{
    public string _entityName;
    public string _className;

    public int _level;
    public int _XP;
    public int _life;
    public int _mana;
    public int _attackSpeed;
    public int _resistance;
    public int _power;
    public int _Cooldown;
}
