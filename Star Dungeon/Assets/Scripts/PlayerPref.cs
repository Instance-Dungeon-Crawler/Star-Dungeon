using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerPref : MonoBehaviour
{
    [SerializeField] ScriptableReader _xander;
    [SerializeField] ScriptableReader _synthia;
    [SerializeField] ScriptableReader _saber;
    [SerializeField] private List<GameObject> _characters = new List<GameObject>();

    void Awake()
    {
        if (!PlayerPrefs.HasKey("GlobalLvl"))
        {
            PlayerPrefs.SetInt("GlobalLvl", 1);
            PlayerPrefs.SetInt("GlobalXP", 0);
            PlayerPrefs.SetInt("threshold", 50);
        }
    }

    private void Start()
    {
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Characters"))
        {
            _characters.Add(gameObject);
        }
        if (PlayerPrefs.GetInt("GlobalXP") >= PlayerPrefs.GetInt("threshold")) 
        {
            PlayerPrefs.SetInt("GlobalLvl", PlayerPrefs.GetInt("GlobalLvl") + 1);
            PlayerPrefs.SetInt("threshold", (PlayerPrefs.GetInt("threshold") + 50));
            foreach (GameObject characters in _characters)
            {
                GameObject.Find(characters.GetComponent<ScriptableReader>()._entityName).GetComponent<ScriptableReader>()._entityLife = GameObject.Find(characters.GetComponent<ScriptableReader>()._entityName).GetComponent<ScriptableReader>()._entityLife * 1.10f;
                GameObject.Find(characters.GetComponent<ScriptableReader>()._entityName).GetComponent<ScriptableReader>()._entityMana = GameObject.Find(characters.GetComponent<ScriptableReader>()._entityName).GetComponent<ScriptableReader>()._entityMana * 1.10f;
                GameObject.Find(characters.GetComponent<ScriptableReader>()._entityName).GetComponent<ScriptableReader>()._entityAttackSpeed = GameObject.Find(characters.GetComponent<ScriptableReader>()._entityName).GetComponent<ScriptableReader>()._entityAttackSpeed * 1.10f;
                GameObject.Find(characters.GetComponent<ScriptableReader>()._entityName).GetComponent<ScriptableReader>()._entityResistance = GameObject.Find(characters.GetComponent<ScriptableReader>()._entityName).GetComponent<ScriptableReader>()._entityResistance * 1.10f;
                GameObject.Find(characters.GetComponent<ScriptableReader>()._entityName).GetComponent<ScriptableReader>()._entityPower = GameObject.Find(characters.GetComponent<ScriptableReader>()._entityName).GetComponent<ScriptableReader>()._entityPower * 1.10f;
            }
        }
    }

    public void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("GlobalLvl", 1);
        PlayerPrefs.SetInt("GlobalXP", 0);
        PlayerPrefs.SetInt("threshold", 50);
    }
}
