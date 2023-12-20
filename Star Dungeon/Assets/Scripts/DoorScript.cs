using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Vector3 _endPosRight;
    public Vector3 _endPosLeft;
    public float _speed = 1f;
    private bool _moving = false;
    private bool _opening = true;
    private Vector3 _startPosRight;
    private Vector3 _startPosLeft;
    private float _delay = 0f;
    public GameObject _doorLeft;
    public GameObject _doorRight;
    public GameObject _player;
    public GameObject _LockedDoorText;

    // Start is called before the first frame update
    void Start()
    {
        _startPosRight = _doorRight.transform.position;
        _startPosLeft = _doorLeft.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(_moving)
        {
            if(_opening) 
            {
                MoveDoor(_endPosRight, _endPosLeft);
                
            }
            else
            {
                MoveDoor(_startPosRight, _startPosLeft);
            }
        }
    }

    void MoveDoor(Vector3 goalposRight, Vector3 goalposLeft)
    {
        float dist = Vector3.Distance(_doorLeft.transform.position, goalposLeft);
        if (dist >= 0.1f)
        {
            _doorLeft.transform.position = Vector3.Lerp(_doorLeft.transform.position, goalposLeft, _speed * Time.deltaTime);
            _doorRight.transform.position = Vector3.Lerp(_doorRight.transform.position, goalposRight, _speed * Time.deltaTime);
        }
        else
        {
            if(_opening)
            {
                _delay += Time.deltaTime;
                if (_delay>1.5f)
                {
                    _opening = false;
                }
            }
            else
            {
                _moving = false;
                _opening = true;

            }
        }
    }

    public bool Moving
    {
        get {return _moving;}
        set { _moving = value;}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") 
        {
            //PlayerPrefs.SetInt("Key", 0);
            //_player.GetComponent<PlayerController>()._haskey--;
            if (!Moving)
            {
                Moving = true;
            }
        }
        // else if (other.tag == "Player" && _player.GetComponent<PlayerController>()._haskey == 1)
        // {
        //     _LockedDoorText.SetActive(true);
        // }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.tag == "Player")
    //     {
    //         _LockedDoorText.SetActive(false);
    //     }
    // }
}
