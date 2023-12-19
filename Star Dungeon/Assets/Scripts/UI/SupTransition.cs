using UnityEngine;
using System.Collections;

public class AnimatedObject : MonoBehaviour
{
    public float _animationDuration = 4f;

    void Start()
    {
       
        StartCoroutine(AnimateAndDestroy());
    }

    IEnumerator AnimateAndDestroy()
    {
        
        yield return new WaitForSeconds(_animationDuration);

    
        Destroy(gameObject);
    }
}