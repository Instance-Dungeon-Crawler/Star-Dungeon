using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    private void Start()
    {

        Screen.SetResolution(1920, 1080, true);

        QualitySettings.SetQualityLevel(1);


    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Devroom");
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(3);
    }

    public void Option()
    {

        SceneManager.LoadScene(2);

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

















