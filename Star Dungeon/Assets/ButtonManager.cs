using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    private void Start()
    {

        Screen.SetResolution(1920, 1080, true);

        QualitySettings.SetQualityLevel(1);


    }

    public void PlayGame()
    {
        SceneManager.LoadScene(4);
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(3);
    }

    public void Option()
    {
        
        SceneManager.LoadScene("MenuSettings");

    }

    public void QuitGame()
    {
        
        Application.Quit();

    }

    public void WindowResolution()
    {

        Screen.SetResolution(800, 600, true);

    }

    public void FullscreenResolution()
    {

        Screen.fullScreen = !Screen.fullScreen;


    }

    public void FullscreenWindowResolution()
    {


        Screen.SetResolution(2560, 1440, true);


    }

    public void Low()
    {
        QualitySettings.SetQualityLevel(0);



    }

    public void Med()
    {


        QualitySettings.SetQualityLevel(1);



    }

    public void High()
    {

        QualitySettings.SetQualityLevel(2);



    }


    



}

















