using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeekDataSO", menuName = "Scriptable Objects/Calendar/WeekDataSO")]
public class WeekDataSO : ScriptableObject
{
    [field: SerializeField]
    public List<Day> dayList { get; private set; }
}

[Serializable]
public struct Day
{
    public string dayName;
}
