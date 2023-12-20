using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AudioClip[] footstep;
    PlayerMovement _playerMovement;
    public int _haskey = 0;
    public AudioSource _audioSource;
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _haskey = PlayerPrefs.GetInt("Key", 0);
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnMoveForward()
    {
        Footstep();
        _playerMovement.Forward(); 
    }

    public void OnMoveBack()
    {
        Footstep();
        _playerMovement.Back();  
    }
    
    public void Footstep()
    {
        AudioClip clip = footstep[UnityEngine.Random.Range(0, footstep.Length)];
        _audioSource .PlayOneShot (clip);
    }
}