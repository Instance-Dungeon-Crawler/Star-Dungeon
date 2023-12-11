using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenInventory : MonoBehaviour
{
    private bool _inventoryIsOpen = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OpenInvent(InputAction.CallbackContext context)
    {
        if (!_inventoryIsOpen)
        {
            if (context.started)
            {
                _inventoryIsOpen = false;
                GameObject.Find("Canvas").transform.Find("Fond Menu").gameObject.SetActive(false);
            }
        }
        if (_inventoryIsOpen)
        {
            if (context.started)
            {
                _inventoryIsOpen = false;
                GameObject.Find("Canvas").transform.Find("Fond Menu").gameObject.SetActive(false);
            }
        }
    }
}
