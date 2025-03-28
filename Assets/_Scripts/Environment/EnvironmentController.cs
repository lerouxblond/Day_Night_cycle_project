using System;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] private GameObject currentbackground;
    [SerializeField] private Camera mainCamera => Camera.main;
    public void newBackground(GameObject backgroundParallaxPrefab)
    {
        if (currentbackground != null)
            Destroy(currentbackground);
        GameObject background = Instantiate(backgroundParallaxPrefab, transform);
        background.transform.SetParent(mainCamera.transform);
        currentbackground = background;
    }

}
