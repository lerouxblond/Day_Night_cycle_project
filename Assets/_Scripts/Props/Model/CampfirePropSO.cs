using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CampfireProp", menuName = "Scriptable Objects/Props/CampfireProp")]
public class CampfirePropSO: Props
{
    #region Campfire Properties
    [field: Header("Campfire Properties")]
    [field: SerializeField]
    public float restingTime { get; set; }
    

    public static CampfirePropSO instance;

    #endregion

    private void Awake()
    {
        instance = this;
    }
}
