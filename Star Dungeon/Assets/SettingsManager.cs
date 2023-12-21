using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    public Toggle _windowded;
    public Toggle _fullscreen;
    public Toggle _windowedFullscreen;

    public Toggle _low;
    public Toggle _medium;
    public Toggle _high;
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        Windows();
    }

    private void Windows()
    {
        if (_windowded.isOn)
        {
            _fullscreen.isOn = false;
            _windowedFullscreen.isOn = false;
        }
        else if (_fullscreen.isOn)
        {
            _windowded.isOn = false;
            _windowedFullscreen.isOn = false;
        }
        else if (_windowedFullscreen.isOn)
        {
            _fullscreen.isOn = false;
            _windowded.isOn = false;
        }
    }
}
