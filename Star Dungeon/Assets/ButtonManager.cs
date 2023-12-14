using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

 
    public void PlayGame()
    {
        SceneManager.LoadScene("Devroom");
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(3);
    }


    public void QuitGame()
    {
        
        Application.Quit();

    }

    public void ScreenResolution()
    {
        string index = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        int largeurEcranApres = Screen.width;
        int hauteurEcranApres = Screen.height;

        switch (index)
        {
            case "0" :
                Screen.SetResolution(1440, 900, true);
                Debug.Log("Nouvelle largeur de l'écran : " + largeurEcranApres);
                Debug.Log("Nouvelle hauteur de l'écran : " + hauteurEcranApres);
                break;

            case "1" :
                Screen.SetResolution(1920, 1080, true);
                Debug.Log("Nouvelle largeur de l'écran : " + largeurEcranApres);
                Debug.Log("Nouvelle hauteur de l'écran : " + hauteurEcranApres);
                break;

            case "2" :
                Screen.SetResolution(2560, 1440, true);
                Debug.Log("Nouvelle largeur de l'écran : " + largeurEcranApres);
                Debug.Log("Nouvelle hauteur de l'écran : " + hauteurEcranApres);
                break;

        

            
        }

       


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

















