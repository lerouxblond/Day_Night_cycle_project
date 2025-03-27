
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonthDataSO", menuName = "Scriptable Objects/Calendar/MonthDataSO")]
public class MonthDataSO : ScriptableObject
{
    [field: SerializeField]
    public string monthName { get; set; } 

    [field: SerializeField]
    public List<Weeks> weeksList { get; private set; }
}

[Serializable]
public struct Weeks
{
    public List<WeekDataSO> week;
}


