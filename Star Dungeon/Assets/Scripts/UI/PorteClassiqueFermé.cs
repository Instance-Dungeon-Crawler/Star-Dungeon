using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteClassiqueFerme : MonoBehaviour
{
    public GameObject _DialoguePorte;
    

    PlayerComponent _playerComponent;

    private void Start()
    {
        _playerComponent = GetComponent<PlayerComponent>();
    }



    void OnTriggerEnter(Collider other)
    {
        if (_playerComponent.key == 0 && other.gameObject.CompareTag("Door"))
        {
            _DialoguePorte.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            _DialoguePorte.SetActive(false);
        }
    } 
}