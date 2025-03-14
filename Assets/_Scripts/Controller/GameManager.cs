using System;
using TimePeriods;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    [SerializeField] private TimeController timeController;
    /*[SerializeField] private calendarManager calendar;*/

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        timeController.InformAboutCycleReset += periodCycleReset;
    }

    private void periodCycleReset(bool obj)
    {
        if (!obj)
            return;
        else
            StartNewDayCycle();
    }

    private void Start()
    {
        StartNewDayCycle();
    }

    public void StartNewDayCycle()
    {
        timeController.newPeriodCycle();
        /*calendar.NewDay();*/
    }

    public void NextPeriod()
    {
        timeController.nextPeriod();
    }
}
