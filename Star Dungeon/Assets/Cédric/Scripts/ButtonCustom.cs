using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UI.Button;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;

public class ButtonCustom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool m_interactable = true;

    [Header("Sprites")]
    [SerializeField] private Sprite m_disable;
    private Sprite m_enable;

    [Header("Colors")]
    [SerializeField] private Color m_enterColor;
    [SerializeField] private Color m_exitColor;
    [SerializeField] private Color m_clickColor;

    [Space(15)]
    [FormerlySerializedAs("onClick")]
    [SerializeField] private ButtonClickedEvent m_onClick = new ButtonClickedEvent();

    [Space(15)]
    [FormerlySerializedAs("onEnter")]
    [SerializeField] private ButtonClickedEvent m_onEnter = new ButtonClickedEvent();

    [Space(15)]
    [FormerlySerializedAs("onExit")]
    [SerializeField] private ButtonClickedEvent m_onExit = new ButtonClickedEvent();
    private void Start()
    {
        m_enable = GetComponent<Image>().sprite;
    }

    private void Update()
    {
        Interactable();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (m_interactable)
        {
            m_onEnter.Invoke();
            if(GetComponentInChildren<TMP_Text>() != null)
                GetComponentInChildren<TMP_Text>().color = m_enterColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (m_interactable)
        {
            m_onExit.Invoke();
            if (GetComponentInChildren<TMP_Text>() != null)
                GetComponentInChildren<TMP_Text>().color = m_exitColor;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (m_interactable)
        {
            m_onClick.Invoke();
            if (GetComponentInChildren<TMP_Text>() != null)
                GetComponentInChildren<TMP_Text>().color = m_clickColor;
        }
    }

    private void Interactable()
    {
        if (!m_interactable)
            GetComponent<Image>().sprite = m_disable;
        else
            GetComponent<Image>().sprite = m_enable;
    }
}
