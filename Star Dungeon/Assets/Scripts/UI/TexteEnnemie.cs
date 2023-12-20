using UnityEngine;

public class TexteEnnemie : MonoBehaviour
{
    public float detectionDistance = 1000f;
    public string objectTag = "Ennemie";
    public GameObject _TexteEnnemie;
    public float displayDuration = 5f;
   
    private bool isShowingText = false;
    private float displayTimer = 0f;
    private bool enemyDetected = false;

    void Update()
    {
       

        if (!enemyDetected) 
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, detectionDistance) && hit.collider.CompareTag(objectTag))
            {
                if (!isShowingText)
                {
                    _TexteEnnemie.SetActive(true);
                    isShowingText = true;
                    displayTimer = displayDuration;
                    enemyDetected = true; 
                }
            }
        }


        else if (isShowingText)
        {
            displayTimer -= Time.deltaTime;

            if (displayTimer <= 0f)
            {
                _TexteEnnemie.SetActive(false);
                isShowingText = false;
                
            }
        }
    }
}
