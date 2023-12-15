using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int _GuerrierHP;
    private int _GuerrierDamage;
    private int _SupportHP;
    private int _SupportDamage;
    private int _VoleurHP;
    private int _VoleurDamage;
    
    enum E_GameState
    {
        E_GodMode, 
        E_NormalMode
    };

    E_GameState GameState = E_GameState.E_NormalMode;


    void Start()
    {
       
        Button yourButton = GetComponent<Button>();
        

    }

    public void ToggleGodMode()
    {
        if (GameState== E_GameState.E_GodMode)
        {
            GameState = E_GameState.E_NormalMode;
        }
        else if(GameState == E_GameState.E_NormalMode) 
        {
            GameState = E_GameState.E_GodMode;
        }
       
        switch(GameState)
        {
            case E_GameState.E_GodMode:
                _GuerrierHP = 100000;
                _GuerrierDamage = 1000000;
                _SupportHP = 100000;
                _SupportDamage = 100000;
                _VoleurHP = 100000;
                _VoleurDamage = 100000;



                break;

            case E_GameState.E_NormalMode:
                _GuerrierHP = 150;
                _GuerrierDamage= 75;
                _SupportHP = 100;
                _SupportDamage = 50;
                _VoleurHP = 75;
                _VoleurDamage = 100;




                break;
             default:
                break;
        }

       

       

        
    }


}
