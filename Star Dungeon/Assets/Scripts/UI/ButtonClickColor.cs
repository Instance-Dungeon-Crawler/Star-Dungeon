using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickColor : MonoBehaviour
{
    
    public Color WantedColor;
    public Button button;


   
    public void ChangeButtonColor() 
    {
        ColorBlock cb = button.colors;
        cb.normalColor = WantedColor;
        cb.highlightedColor = WantedColor;
        cb.pressedColor = WantedColor;
        button.colors = cb;



    }

}
