using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.position = GameObject.Find("Player").transform.position;
        transform.position = new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y + 600, GameObject.Find("Player").transform.position.z);
    }
}
