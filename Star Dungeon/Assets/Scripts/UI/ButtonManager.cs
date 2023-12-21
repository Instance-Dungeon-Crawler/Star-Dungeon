using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _credits, _mainMenu;
    public AudioSource _audioSource;
    private void Start()
    {
        _audioSource.Play();
        Screen.SetResolution(1920, 1080, true);
        QualitySettings.SetQualityLevel(1);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        if (_mainMenu.activeSelf)
        {
            _credits.SetActive(true);   
            _mainMenu.SetActive(false);
        }
        else if (_credits.activeSelf)
        {
            _credits.SetActive(false);
            _mainMenu.SetActive(true);
        }
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void WindowResolution()
    {
        Screen.SetResolution(1600, 900, true);
    }
    public void FullscreenResolution()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void FullscreenWindowResolution()
    {
        Screen.SetResolution(2560, 1440, true);
    }
    public void low()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void med()
    {
        QualitySettings.SetQualityLevel(1);
    }
    public void high()
    {
        QualitySettings.SetQualityLevel(2);
    }
}