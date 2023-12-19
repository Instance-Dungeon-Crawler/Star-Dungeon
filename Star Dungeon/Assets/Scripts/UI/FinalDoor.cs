using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public GameObject _DialoguePorteFinal;
    public int _haskey;

    void OnTriggerEnter(Collider other)
    {
        if (_haskey == 0 && other.gameObject.CompareTag("FinalDoor"))
        {



            _DialoguePorteFinal.SetActive(true);


        }



    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FinalDoor"))
        {
            _DialoguePorteFinal.SetActive(false);
        }
    }


}