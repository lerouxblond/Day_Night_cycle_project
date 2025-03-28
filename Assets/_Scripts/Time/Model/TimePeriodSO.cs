using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TimePeriodSO", menuName = "Scriptable Objects/TimePeriod/TimePeriodSO")]
public class TimePeriodSO : ScriptableObject
{
    [field: SerializeField] public string periodName { get; set; }
    public int ID => GetInstanceID();
    [field: SerializeField] public GameObject backgroundParallaxPrefab { get; set; }



}

