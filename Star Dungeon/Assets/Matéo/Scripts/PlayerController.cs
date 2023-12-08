using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    PlayerMovement _playerMovement;
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
      
    }

    public void OnMove(Vector3 _vector3)
    {
        _playerMovement.Move(_vector3);
    }

    
   
}
