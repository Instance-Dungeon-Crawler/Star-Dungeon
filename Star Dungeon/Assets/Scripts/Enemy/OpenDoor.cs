using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public AnimationCurve _openSpeedCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0, 1, 0, 0), new Keyframe(0.8f, 1, 0, 0), new Keyframe(1, 0, 0, 0) }); 
    public float _openSpeedMultiplier = 2.0f;
    public float _doorOpenAngle = 90.0f;

    bool open = false;
    bool enter = false;

    float _defaultRotationAngle;
    float _currentRotationAngle;
    float _openTime = 0;

    void Start()
    {
        _defaultRotationAngle = transform.localEulerAngles.y;
        _currentRotationAngle = transform.localEulerAngles.y;

        GetComponent<Collider>().isTrigger = true;
    }

    void Update()
    {
        if (_openTime < 1)
        {
            _openTime += Time.deltaTime * _openSpeedMultiplier * _openSpeedCurve.Evaluate(_openTime);
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.LerpAngle(_currentRotationAngle, _defaultRotationAngle + (open ? _doorOpenAngle : 0), _openTime), transform.localEulerAngles.z);

        if (Input.GetKeyDown(KeyCode.F) && enter)
        {
            open = !open;
            _currentRotationAngle = transform.localEulerAngles.y;
            _openTime = 0;
        }
    }

    void OnGUI()
    {
        if (enter)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 30), "Press 'F' to " + (open ? "close" : "open") + " the door");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = false;
        }
    }
}
