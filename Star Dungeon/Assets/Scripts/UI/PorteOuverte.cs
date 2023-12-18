using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteOuverte : MonoBehaviour
{
    public GameObject _DialoguePorteOuverte;
    public int _haskey;

    void OnTriggerEnter(Collider other)
    {
        if (_haskey == 1 && other.gameObject.CompareTag("Door"))
        {



            _DialoguePorteOuverte.SetActive(true);


        }



    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            _DialoguePorteOuverte.SetActive(false);
        }
    }












}
