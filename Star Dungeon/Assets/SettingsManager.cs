using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SettingsManager : MonoBehaviour
{

    public Toggle _windowded;
    public Toggle _fullscreen;
    public Toggle _windowedFullscreen;

    public Toggle _low;
    public Toggle _medium;
    public Toggle _high;

    private int _index;
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        Windows();
        Quality();
    }

    private void Windows()
    {
        if (_windowded.isOn)
        {
            _fullscreen.isOn = false;
            _windowedFullscreen.isOn = false;
            Screen.SetResolution(960, 540, FullScreenMode.Windowed, 60);
        }
        else if (_fullscreen.isOn)
        {
            _windowded.isOn = false;
            _windowedFullscreen.isOn = false;
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        }
        else if (_windowedFullscreen.isOn)
        {
            _fullscreen.isOn = false;
            _windowded.isOn = false;
            
            Screen.SetResolution(1920, 1080, FullScreenMode.Windowed, 60);
        }
    }

    private void Quality()
    {
        if (_low.isOn)
        {
            _medium.isOn = false;   
            _high.isOn = false;
            
            //QualitySettings.SetQualityLevel(0, true);
        }
        else if (_medium.isOn)
        {
            _low.isOn = false;
            _high.isOn = false;
            
            //QualitySettings.SetQualityLevel(2, true);
        }
        else if (_high.isOn)
        {
            _low.isOn = false;
            _medium.isOn = false;
            
            //QualitySettings.SetQualityLevel(5, true);
        }   
    }
}
