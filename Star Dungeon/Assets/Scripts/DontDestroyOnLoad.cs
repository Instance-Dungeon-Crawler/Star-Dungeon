using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);    
    }

    private void Awake()
    {
        Save.Instance.LoadFromJSON();
    }
}
