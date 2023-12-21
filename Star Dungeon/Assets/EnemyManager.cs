using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> _enemies = new List<GameObject>();
    public GameObject _enemyInBattle;

    public static EnemyManager Instance;
    [SerializeField] private GameObject Combat_Canva;
    [SerializeField] private  GameObject Combat_Text;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.Log("There is two enemy manager");
            Destroy(this);
            return;
        }

    }

    private void Start()
    {
        DontDestroyOnLoad(this);
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            _enemies.Add(enemy);

            if (enemy.GetComponent<EnnemiAI>()._isDead)
            {
                enemy.SetActive(false);
            }
        }
    }

    public void StartCombat(GameObject enemy)
    {
        foreach (var _robot in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            _robot.SetActive(false);
        }

        
        _enemyInBattle = enemy;
        _enemies.Remove(_enemyInBattle);
        new BattleButtonsManager();
        Combat_Text.SetActive(true);
        Combat_Canva.SetActive(true);

        // Save.Instance.SaveToJSON();
        // SceneManager.LoadScene("Battle Scene");   
        
    }
}
