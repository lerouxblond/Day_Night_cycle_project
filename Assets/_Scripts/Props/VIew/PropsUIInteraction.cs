using System;
using UnityEngine;
using UnityEngine.UI;

public class PropsUIInteraction : MonoBehaviour
{
    [SerializeField] private Text propInteractionText;

    public CampfirePropSO campFireInstance;

    private void Awake()
    {
        propInteractionText = GetComponentInChildren<Text>();
        propInteractionText.enabled = false;

        campFireInstance.OnPlayerEnter += OnPlayerEnter;
        campFireInstance.OnPlayerExit += OnPlayerExit;
    }

    private void OnPlayerExit()
    {
        propInteractionText.enabled = false;
    }

    private void OnPlayerEnter()
    {
        propInteractionText.enabled = true;
        propInteractionText.text = $"Press E to interact with {campFireInstance.propName}";
    }
}
