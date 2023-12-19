using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuFin : MonoBehaviour
{
    public GameObject _TitreSuivant;
    public GameObject _TextHistoire;

    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        _TextHistoire.SetActive(false);
        _TitreSuivant.SetActive(true);

        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
