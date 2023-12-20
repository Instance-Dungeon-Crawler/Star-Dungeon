using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GestionPortes : MonoBehaviour
{
    public GameObject _PremiereSalle;
    public GameObject _TroisiemeSalle;
    private bool isShowingText = false;
    private float displayTimer = 0f;
    private List<GameObject> PortesFranchies = new List<GameObject>();
    private WaitForSeconds cooldown = new WaitForSeconds(5f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null)
        {
            GameObject porte = other.gameObject;

            if(other.gameObject.name == "Door")
            {

                if (!PortesFranchies.Contains(porte))
                {
                    PortesFranchies.Add(porte);
                    AfficherMessage();
                }

            }

          
        }
    }

    private void AfficherMessage()
    {
        Debug.Log("Portes franchies: " + PortesFranchies.Count);

        if (PortesFranchies.Count == 1)
        {
            if (!isShowingText)
            {
                StartCoroutine(DisplayTextCoroutine(_PremiereSalle));
            }
        }

        if (PortesFranchies.Count == 3)
        {
            if (!isShowingText)
            {
                StartCoroutine(DisplayTextCoroutine(_TroisiemeSalle));
            }
        }
    }

    private IEnumerator DisplayTextCoroutine(GameObject salle)
    {
        isShowingText = true;
        salle.SetActive(true);

        yield return cooldown;

        salle.SetActive(false);
        isShowingText = false;
    }
}
