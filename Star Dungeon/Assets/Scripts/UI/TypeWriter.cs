using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{

    public GameObject _TitreSuivant;
    public GameObject _TextHistoire;
    Text uiText;
    string Originaletexte;
    

    public float _Delai = 0.2f;
    public bool isTyping = true;
    public float _time = 1;
    void Awake()
    {
        uiText = _TextHistoire.GetComponent<Text>();
        Originaletexte = uiText.text;
        uiText.text = null;
        StartCoroutine(ShowLetterByLetter());
    }

    void Update()
    {
        

        if (isTyping && (Keyboard.current.anyKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame))
        {
            StopAllCoroutines();
            uiText.text = Originaletexte;
            isTyping = false;
        }

        if (!isTyping)
        {
             _time -= Time.deltaTime;



        }

        if (!isTyping && (Keyboard.current.anyKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame) && _time <0)
        {
            Debug.Log("test");
            EndGame();

        }

    }

    IEnumerator ShowLetterByLetter()
    {
        for (int i = 0; i <= Originaletexte.Length; i++)
        {
            uiText.text = Originaletexte.Substring(0, i);
            yield return new WaitForSeconds(_Delai);
        }

        isTyping = false;
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
        SceneManager.LoadScene("MainMenu");
    }

}