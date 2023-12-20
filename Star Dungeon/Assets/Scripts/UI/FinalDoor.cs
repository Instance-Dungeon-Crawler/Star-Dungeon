using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (_haskey == 1 && other.gameObject.CompareTag("FinalDoor"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FinalDoor"))
        {
            _DialoguePorteFinal.SetActive(false);
        }
    }
}