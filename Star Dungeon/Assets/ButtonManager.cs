using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

}
