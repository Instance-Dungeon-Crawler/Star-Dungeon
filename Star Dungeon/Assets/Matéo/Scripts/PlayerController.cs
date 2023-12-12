using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement _playerMovement;
    private Rigidbody _rigidBody;
  
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        
    }

    public void OnMove()
    {
     
            _playerMovement.Movements();
           
    }

}
