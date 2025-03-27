using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CalendarDataSO", menuName = "Scriptable Objects/Calendar/CalendarDataSO")]
public class CalendarDataSO : ScriptableObject
{
    public static CalendarDataSO instance;

    [field: SerializeField]
    public List<SeasonDataSO> seasonsList { get; set; }

    [field: SerializeField] public int currentDayIndex { get;  set; } = 0;
    [field: SerializeField] public int currentWeekIndex { get;  set; } = 0;
    [field: SerializeField] public int currentMonthIndex { get;  set; } = 0;
    [field: SerializeField] public int currentSeasonIndex { get;  set; } = 0;


    public UnityAction<int> onDayChange;
    public UnityAction<int> onWeekChange;
    public UnityAction<int> onMonthChange;
    public UnityAction<int> onSeasonChange;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void OnNextDay()
    {
        if(currentDayIndex < seasonsList[currentSeasonIndex].monthList[0].month[currentMonthIndex].weeksList[0].week[currentWeekIndex].dayList.Count)
        {
            currentDayIndex++;
            onDayChange?.Invoke(currentDayIndex);
        }
        else if (currentDayIndex == seasonsList[currentSeasonIndex].monthList[0].month[currentMonthIndex].weeksList[0].week[currentWeekIndex].dayList.Count)
        {
            currentDayIndex = 0;
            OnNextWeek();
            onDayChange?.Invoke(currentDayIndex);
        }
    }

    public void OnNextWeek()
    {
        if(currentWeekIndex < seasonsList[currentSeasonIndex].monthList[0].month[currentMonthIndex].weeksList.Count)
        {
            currentWeekIndex++;
            onWeekChange?.Invoke(currentWeekIndex);
        }
        else if (currentWeekIndex == seasonsList[currentSeasonIndex].monthList[0].month[currentMonthIndex].weeksList.Count)
        {
            currentWeekIndex = 0;
            OnNextMonth();
            onWeekChange?.Invoke(currentWeekIndex);
        }
    }

    public void OnNextMonth()
    {
        if(currentMonthIndex < seasonsList[currentSeasonIndex].monthList[0].month.Count-1)
        {
            currentMonthIndex++;
            onMonthChange?.Invoke(currentMonthIndex);
        }
        else if (currentMonthIndex == seasonsList[currentSeasonIndex].monthList[0].month.Count-1)
        {
            currentMonthIndex = 0;
            OnNextSeason();
            onMonthChange?.Invoke(currentMonthIndex);
        }
    }


    public void OnNextSeason()
    {
        if(currentSeasonIndex < seasonsList.Count-1)
        {
            currentSeasonIndex++;
            onSeasonChange?.Invoke(currentSeasonIndex);
        }
        else if (currentSeasonIndex == seasonsList.Count- 1)
        {
            currentSeasonIndex = 0;
            onSeasonChange?.Invoke(currentSeasonIndex);
        }
    }

    public string getSeasonNameByIndex(int seasonIndex)
    {
        return seasonsList[seasonIndex].seasonName;
    }

    public string getMonthNameByIndex(int monthIndex)
    {
        return seasonsList[currentSeasonIndex].monthList[0].month[monthIndex].monthName;
    }
}