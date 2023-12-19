using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial : MonoBehaviour
{
    public void TutorialAvancement(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameObject.Find("HUD").transform.Find("Touch").gameObject.SetActive(false);
        }
    }
}
