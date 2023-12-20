using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteClassiqueFerme : MonoBehaviour
{
    public GameObject _DialoguePorte;
    public int _haskey;

    void OnTriggerEnter(Collider other)
    {
        if (_haskey == 0 && other.gameObject.CompareTag("Door"))
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