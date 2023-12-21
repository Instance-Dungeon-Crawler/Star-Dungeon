using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject _pause;
    public void Resume()
    {
        _pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
