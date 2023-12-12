using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image Image;
    [HideInInspector] public Transform _parentAfterDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("StartDrag");
        _parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        Image.raycastTarget = false;
        if (_parentAfterDrag.tag == "Slot 1 (4)")
        {
            GameObject.Find("Xander").GetComponent<ScriptableReader>()._playerAttackSpeed -= Image.GetComponent<ScriptableReaderEquipement>()._equipementAttackSpeed;
            GameObject.Find("Xander").GetComponent<ScriptableReader>()._playerPower -= Image.GetComponent<ScriptableReaderEquipement>()._equipementPower;
            print(GameObject.Find("Xander").GetComponent<ScriptableReader>()._playerAttackSpeed);
            print(GameObject.Find("Xander").GetComponent<ScriptableReader>()._playerPower);
        }
        if (_parentAfterDrag.tag == "Slot 1 (5)")
        {
            GameObject.Find("Synthia").GetComponent<ScriptableReader>()._playerAttackSpeed += Image.GetComponent<ScriptableReaderEquipement>()._equipementAttackSpeed;
            GameObject.Find("Synthia").GetComponent<ScriptableReader>()._playerPower += Image.GetComponent<ScriptableReaderEquipement>()._equipementPower;
        }
        if (_parentAfterDrag.tag == "Slot 1 (6)")
        {
            GameObject.Find("Saber").GetComponent<ScriptableReader>()._playerAttackSpeed += Image.GetComponent<ScriptableReaderEquipement>()._equipementAttackSpeed;
            GameObject.Find("Saber").GetComponent<ScriptableReader>()._playerPower += Image.GetComponent<ScriptableReaderEquipement>()._equipementPower;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Draging");
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        transform.SetParent(_parentAfterDrag);
        Image.raycastTarget = true;
        if (_parentAfterDrag.tag == "Slot 1 (4)")
        {
            GameObject.Find("Xander").GetComponent<ScriptableReader>()._playerAttackSpeed += Image.GetComponent<ScriptableReaderEquipement>()._equipementAttackSpeed;
            GameObject.Find("Xander").GetComponent<ScriptableReader>()._playerPower += Image.GetComponent<ScriptableReaderEquipement>()._equipementPower;
            print(GameObject.Find("Xander").GetComponent<ScriptableReader>()._playerAttackSpeed);
            print(GameObject.Find("Xander").GetComponent<ScriptableReader>()._playerPower);
        }
        if (_parentAfterDrag.tag == "Slot 1 (5)")
        {
            GameObject.Find("Synthia").GetComponent<ScriptableReader>()._playerAttackSpeed += Image.GetComponent<ScriptableReaderEquipement>()._equipementAttackSpeed;
            GameObject.Find("Synthia").GetComponent<ScriptableReader>()._playerPower += Image.GetComponent<ScriptableReaderEquipement>()._equipementPower;
            print(GameObject.Find("Synthia").GetComponent<ScriptableReader>()._playerAttackSpeed);
            print(GameObject.Find("Synthia").GetComponent<ScriptableReader>()._playerPower);
        }
        if (_parentAfterDrag.tag == "Slot 1 (6)")
        {
            GameObject.Find("Saber").GetComponent<ScriptableReader>()._playerAttackSpeed += Image.GetComponent<ScriptableReaderEquipement>()._equipementAttackSpeed;
            GameObject.Find("Saber").GetComponent<ScriptableReader>()._playerPower += Image.GetComponent<ScriptableReaderEquipement>()._equipementPower;
            print(GameObject.Find("Saber").GetComponent<ScriptableReader>()._playerAttackSpeed);
            print(GameObject.Find("Saber").GetComponent<ScriptableReader>()._playerPower);
        }
    }
}
