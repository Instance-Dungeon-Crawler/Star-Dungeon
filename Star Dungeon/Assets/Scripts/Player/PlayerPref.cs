using UnityEngine;

public class PlayerPref : MonoBehaviour
{
    [SerializeField] ScriptableReader _xander;
    [SerializeField] ScriptableReader _synthia;
    [SerializeField] ScriptableReader _saber;
    void Awake()
    {
        //Xander Stats
        PlayerPrefs.SetInt("GlobalLvl", _xander._entityLevel);
        PlayerPrefs.SetInt("GlobalXP", _xander._entityXP);
        PlayerPrefs.SetInt("threshold", _xander._threshold);
        PlayerPrefs.SetFloat("xanderLife",_xander._entityLife);
        PlayerPrefs.SetFloat("xanderMana",_xander._entityMana);
        PlayerPrefs.SetFloat("xanderAttackSpeed",_xander._entityAttackSpeed);
        PlayerPrefs.SetFloat("xanderResistance",_xander._entityResistance);
        PlayerPrefs.SetFloat("xanderPower", _xander._entityPower);

        //Synthia Stats
        PlayerPrefs.SetInt("synthiaLvl", _synthia._entityLevel);
        PlayerPrefs.SetInt("synthiaXP", _synthia._entityXP);
        PlayerPrefs.SetFloat("synthiaLife", _synthia._entityLife);
        PlayerPrefs.SetFloat("synthiaMana", _synthia._entityMana);
        PlayerPrefs.SetFloat("synthiaAttackSpeed", _synthia._entityAttackSpeed);
        PlayerPrefs.SetFloat("synthiaResistance", _synthia._entityResistance);
        PlayerPrefs.SetFloat("synthiaPower", _synthia._entityPower);

        //_saber Stats
        PlayerPrefs.SetInt("saberLvl", _saber._entityLevel);
        PlayerPrefs.SetInt("saberXP", _saber._entityXP);
        PlayerPrefs.SetFloat("saberLife", _saber._entityLife);
        PlayerPrefs.SetFloat("saberMana", _saber._entityMana);
        PlayerPrefs.SetFloat("saberAttackSpeed", _saber._entityAttackSpeed);
        PlayerPrefs.SetFloat("saberResistance", _saber._entityResistance);
        PlayerPrefs.SetFloat("saberPower", _saber._entityPower);
    }
}
