using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _inventory, _iconInventory;
    public void Inventory()
    {
        if (!_inventory.activeSelf)
        {
            _inventory.SetActive(true);
            _iconInventory.SetActive(false);
        }
        else 
        {
            _inventory.SetActive(false);
            _iconInventory.SetActive(true);
        }
    }
}
