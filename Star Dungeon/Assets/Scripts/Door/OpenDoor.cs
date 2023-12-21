using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] AudioSource _openDoor;
    [SerializeField] AudioSource _closeDoor;
    private bool _canOpenDoor = false;
    private bool _canCloseDoor = false;
    

    private Vector3 _initRightDoorPosition;
    private Vector3 _initLeftDoorPosition;


    private void Start()
    {
        _initRightDoorPosition = transform.GetChild(0).GetChild(1).localPosition;
        _initLeftDoorPosition = transform.GetChild(0).GetChild(0).localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _openDoor.Play();
            _canOpenDoor = true;
            _canCloseDoor = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _closeDoor.Play();
            _canCloseDoor = true;
            _canOpenDoor = false;
        }
    }

    private void Update()
    {
        MoveDoor();
        CloseDoor();
    }

    private void MoveDoor()
    {
        if (_canOpenDoor && transform.GetChild(0).GetChild(0).localPosition.z <= 2 && transform.localRotation.y > 0)
        {
            transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
            transform.GetChild(0).GetChild(0).Translate(-transform.right * (10f * Time.deltaTime));
            transform.GetChild(0).GetChild(1).Translate(transform.right * (10f * Time.deltaTime));
        }
        else if (_canOpenDoor && transform.GetChild(0).GetChild(0).localPosition.z <= 2 && transform.rotation.y == 0)
        {
            transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
            transform.GetChild(0).GetChild(0).Translate(transform.forward * (10f * Time.deltaTime));
            transform.GetChild(0).GetChild(1).Translate(- transform.forward * (10f * Time.deltaTime));    
        }
    }

    private void CloseDoor()
    {
        if (_canCloseDoor && transform.GetChild(0).GetChild(0).localPosition.z > 0 && transform.localRotation.y > 0)
        {
            transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
            transform.GetChild(0).GetChild(0).Translate(transform.right * (10f * Time.deltaTime));
            transform.GetChild(0).GetChild(1).Translate(-transform.right * (10f * Time.deltaTime));
        }
        else if (_canCloseDoor && transform.GetChild(0).GetChild(0).localPosition.z > 0 && transform.rotation.y == 0)
        {
            transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
            transform.GetChild(0).GetChild(0).Translate(-transform.forward * (10f * Time.deltaTime));
            transform.GetChild(0).GetChild(1).Translate(transform.forward * (10f * Time.deltaTime));       
        }
    }
}
