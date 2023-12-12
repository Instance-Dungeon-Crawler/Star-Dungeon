using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement _playerMovement;
    public int _haskey = 0;
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _haskey = PlayerPrefs.GetInt("Key", 0);
    }

    public void OnMove()
    {
        _playerMovement.Movements(); 
    }

}
