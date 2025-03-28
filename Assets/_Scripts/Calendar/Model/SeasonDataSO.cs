
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SeasonDataSO", menuName = "Scriptable Objects/Calendar/SeasonDataSO")]
public class SeasonDataSO : ScriptableObject
{
    [field: SerializeField]
    public string seasonName { get; set; }

    [field: SerializeField, TextArea]
    public string seasonDescription { get; set; }

    [field: SerializeField]
    public List<MonthDataSO> monthList { get; private set; }
}

