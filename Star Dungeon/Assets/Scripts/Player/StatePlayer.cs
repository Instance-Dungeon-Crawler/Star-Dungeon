    using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class StatePlayer : ScriptableObject
{
    public string _playerName;
    public string _className;

    public int _life;
    public int _mana;
    public int _attackSpeed;
    public int _resistance;
    public int _power;
}