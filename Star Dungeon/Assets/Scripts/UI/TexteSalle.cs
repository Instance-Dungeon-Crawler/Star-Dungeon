using UnityEngine;
using System.Collections.Generic;

public class GestionPortes : MonoBehaviour
{
    public GameObject _PremiereSalle;
    public GameObject _TroisiemeSalle;

    private List<string> PortesFranchies = new List<string>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DoorOpen"))
        {
            string nomPorte = other.gameObject.name;

            if (!PortesFranchies.Contains(nomPorte))
            {
                PortesFranchies.Add(nomPorte);
                AfficherMessage(nomPorte);
            }
        }
    }

    private void AfficherMessage(string nomPorte)
    {
        switch (nomPorte)
        {
            case "Door":
                _PremiereSalle.SetActive(true);
                break;

            case "Porte3":
                _TroisiemeSalle.SetActive(true);
                break;

            default:
                Debug.Log("test");
                break;
        }
    }
}
