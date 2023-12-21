using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    public GameObject _DialoguePorteFinal;
  

    PlayerComponent _playerComponent;

    private void Start()
    {
        _playerComponent = GetComponent<PlayerComponent>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (_playerComponent.key == 0 && other.GetComponent<Collider>().tag == "FinalDoor")
        {
            _DialoguePorteFinal.SetActive(true);
        }

        if (_playerComponent.key >= 1 && other.gameObject.CompareTag("FinalDoor"))
        {
            SceneManager.LoadScene("EndGame");
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