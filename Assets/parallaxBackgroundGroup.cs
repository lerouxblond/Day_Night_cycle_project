using System.Collections.Generic;
using UnityEngine;

public class parallaxBackgroundGroup : MonoBehaviour
{
    [SerializeField] public List<parallaxBackgroundController> parallaxBackgrounds;

    void Awake()
    {
        parallaxBackgrounds = new List<parallaxBackgroundController>();
        parallaxBackgrounds.AddRange(transform.GetComponentsInChildren<parallaxBackgroundController>());
        // Hide();
    }

    public void Hide()
    {
        foreach (parallaxBackgroundController background in parallaxBackgrounds)
        {
            background.gameObject.SetActive(false);
        }
    }

    public void Show()
    {
        foreach (parallaxBackgroundController background in parallaxBackgrounds)
        {
            background.gameObject.SetActive(true);
        }
    }
}
