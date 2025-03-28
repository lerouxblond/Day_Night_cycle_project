using System;
using UnityEngine;
using UnityEngine.Events;


public abstract class Props : ScriptableObject
{
    #region ¨Prop Properties
    [field: Header("Prop Properties")]

    [field: SerializeField]
    public string propName { get; set; }

    [field: SerializeField, TextArea]
    public string propDescription { get; set; }

    [field: SerializeField]
    public GameObject propSpritePrefab { get; set; }

    public UnityAction OnPlayerEnter;
    public UnityAction OnPlayerExit;

    #endregion
}
