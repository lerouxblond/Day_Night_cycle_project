using System;
using UnityEngine;
using UnityEngine.UI;

public class calendarUI : MonoBehaviour
{
    [SerializeField] private Text dayText;
    [SerializeField] private Text weekText;
    [SerializeField] private Text monthText;
    [SerializeField] private Text seasonText;




    public void UpdateSeasonText(string seasonName)
    {
        seasonText.text = $"{seasonName}";
    }

    public void UpdateMonthText(string monthName)
    {
        monthText.text = $"{monthName}";
    }

    public void UpdateWeekText(int weekIndex)
    {
        weekText.text = $"WEEK {weekIndex + 1}";
    }

    public void UpdateDayText(int dayIndex)
    {

        dayText.text = $"DAY {dayIndex + 1}";
    }


}