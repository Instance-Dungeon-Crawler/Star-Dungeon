using UnityEngine;

public class TexteApparition : MonoBehaviour
{
    public GameObject _prefabTexteDebut;

    void Start()
    {
        ActiverTexteDebut();
    }




    void ActiverTexteDebut()
    {
        
       _prefabTexteDebut.SetActive(true);

       

        Invoke("DesactiverTexteDebut", 6f);
    }

    void DesactiverTexteDebut()
    {
        _prefabTexteDebut.SetActive(false);
    }
}
