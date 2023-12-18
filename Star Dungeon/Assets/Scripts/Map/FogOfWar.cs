using System;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    [SerializeField] private GameObject _fog;
    [SerializeField] private List<GameObject> _playerDetection = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (var obj in _fog.GetComponentsInChildren<Transform>())
            {
                obj.gameObject.layer = LayerMask.NameToLayer("DisableFog");  
            }

            foreach (var obj in _playerDetection)
            {
                //obj.GetComponent<FogOfWar>().enabled = false;
                Destroy(obj);
            }
        }
    }
}
