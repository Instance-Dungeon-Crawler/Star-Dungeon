using UnityEngine;
using UnityEngine.UI;

public class GestionToggle : MonoBehaviour
{
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;

    private void Start()
    {
        
        toggle1.onValueChanged.AddListener(delegate { OnToggleValueChanged(toggle1); });
        toggle2.onValueChanged.AddListener(delegate { OnToggleValueChanged(toggle2); });
        toggle3.onValueChanged.AddListener(delegate { OnToggleValueChanged(toggle3); });
    }

    private void OnToggleValueChanged(Toggle toggle)
    {
       
        if (toggle.isOn)
        {
            if (toggle == toggle1)
            {
                toggle2.isOn = false;
                toggle3.isOn = false;
            }
            else if (toggle == toggle2)
            {
                toggle1.isOn = false;
                toggle3.isOn = false;
            }
            else if (toggle == toggle3)
            {
                toggle1.isOn = false;
                toggle2.isOn = false;
            }
        }
    }
}
