using System;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    private GameObject currentBackground;
    [SerializeField] private Camera mainCam;

    void Awake()
    {
        if (mainCam != null)
            return;
        else
            mainCam = Camera.main;
    }

    public void changeBackground(GameObject backgroundParallaxPrefab)
    {
        if(currentBackground != null)
            Destroy(currentBackground);
        
        if(backgroundParallaxPrefab != null)
        {
            GameObject newBackground = Instantiate(backgroundParallaxPrefab);
            newBackground.transform.SetParent(mainCam.transform, false);
            currentBackground = newBackground;
        }
        else
        {
            Debug.LogWarning($"No background prefab assigned for this period");
        }
    }
}
