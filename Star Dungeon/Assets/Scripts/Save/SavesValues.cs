using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveValues : MonoBehaviour
{
    public List<Vector3> Position_Enemy = new List<Vector3>();
    public Vector3 Position_Player;
    public List<bool> IsDead = new List<bool>();
    
    public static SaveValues Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
