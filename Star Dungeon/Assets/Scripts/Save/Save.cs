using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Save : MonoBehaviour
{
    public SaveValues SaveValues = new SaveValues();

    private string saveFolderPath = Application.dataPath + "/Saves";

    private GameObject Player;
    private List<Vector3> EnemysV3 = new List<Vector3>();
    private List<bool> EnemyBool = new List<bool>();

    [SerializeField] private ScriptableReader _enemy;

    public static Save Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.Log("Destroy !save");
            Destroy(this);
            return;
        }
    }

    private void Start()
    {
        
        Player = GameObject.Find("Player").GetComponent<PlayerMovement>().gameObject;
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (enemy != null)
            {
                EnemyBool.Add(enemy.GetComponent<EnnemiAI>()._isDead);
                
                EnemysV3.Add(enemy.gameObject.transform.position);
            }
        }
        
        if (!Directory.Exists(saveFolderPath))
        {
            Directory.CreateDirectory(saveFolderPath);
        }
        if (File.Exists(Application.dataPath + "/Saves/SaveValues.json"))
        {
            LoadFromJSON();
        }
        else
        {
            SaveToJSON();
        }
    }

    public void SaveToJSON()
    {
        SaveValues.Position_Player = Player.transform.position;
        SaveValues.Position_Enemy = EnemysV3;
        SaveValues.IsDead = EnemyBool;

        string gameData = JsonUtility.ToJson(SaveValues);
        File.WriteAllText(Application.dataPath + "/Saves/SaveValues.json", gameData);
    }
    public void LoadFromJSON()
    {
        string filePath = Application.dataPath + "/Saves/SaveValues.json";
        string gameData = File.ReadAllText(filePath);

        SaveValues = JsonUtility.FromJson<SaveValues>(gameData);
        Player.transform.position = SaveValues.Position_Player;
        EnemysV3 = SaveValues.Position_Enemy;
        EnemyBool = SaveValues.IsDead; 
    }
}
