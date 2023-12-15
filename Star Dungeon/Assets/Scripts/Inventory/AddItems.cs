using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItems : MonoBehaviour
{
    public GameObject _equipement;
    public PlayerController _playerController;
    int index = 0;
    public List<GameObject> _items = new List<GameObject>();
    private void Start()
    {   
    }

    private void Update()
    {
        if (_playerController._haskey == 1 && index == 0)
        {
            index++;
            Debug.Log("caca");
            AddInventoryEquipement();
        }
    }
    public void AddInventoryEquipement()
    {
        Instantiate(_equipement, _items[0].transform);
    }
}
