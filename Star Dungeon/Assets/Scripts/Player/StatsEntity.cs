    using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity")]
public class StatsEntity : MonoBehaviour
{
    public string _entityname;
    public string _name;

    public int _life;
    public int _mana;
    public int _attackSpeed;
    public int _resistance;
    public int _power;
}
