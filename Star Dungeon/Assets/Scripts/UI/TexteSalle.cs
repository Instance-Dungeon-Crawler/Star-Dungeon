using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexteSalle : MonoBehaviour
{
    private List<GameObject> salles = new List<GameObject>();

    public int _haskey;
    public GameObject _PrefabSalle;

    private void OnTriggerEnter(Collider other)
    {
        if (_haskey == 0 && other.CompareTag("DoorOpen"))
        {
            salles.Add(other.gameObject);
            GameObject firstDoor = salles[0];

            if (firstDoor != null)
            {

                _PrefabSalle.SetActive(true);



            }
         

            
           



        }

       
    }

    void OnTriggerExit(Collider other)
    {
        if (_haskey == 0 && other.gameObject.CompareTag("DoorOpen"))
        {
            _PrefabSalle.SetActive(false);
        }
    }
}
