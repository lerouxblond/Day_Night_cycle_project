using System;
using System.Globalization;
using TimePeriods;
using UnityEngine;

public class CalendarController : MonoBehaviour
{
    [SerializeField] private TimeController time;
    public CalendarDataSO calendarData;
    [SerializeField] private calendarUI calendarUI;


    private void Awake()
    {
        time.InformAboutCycleReset += nextDay;

        calendarData.onDayChange += calendarUI.UpdateDayText;

        calendarData.onWeekChange += calendarUI.UpdateWeekText;

        calendarData.onMonthChange += updateMonthUI;

        calendarData.onSeasonChange += updateSeasonUI;

    }

    private void Start()
    {
        initUI();
    }

    private void initUI()
    {
        calendarUI.UpdateDayText(calendarData.currentDayIndex);
        calendarUI.UpdateWeekText(calendarData.currentWeekIndex);
        updateMonthUI(calendarData.currentMonthIndex);
        updateSeasonUI(calendarData.currentSeasonIndex);
    }

    private void updateSeasonUI(int seasonIndex)
    {
        string seasonName = calendarData.getSeasonNameByIndex(seasonIndex);
        calendarUI.UpdateSeasonText(seasonName);
    }

    private void updateMonthUI(int monthIndex)
    {
        string monthName = calendarData.getMonthNameByIndex(monthIndex);
        calendarUI.UpdateMonthText(monthName);
    }

    private void nextDay()
    {
        calendarData.OnNextDay();
    }


}