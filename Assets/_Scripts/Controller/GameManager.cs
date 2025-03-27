using System;
using TimePeriods;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    [SerializeField] private TimeController timeController;
    [SerializeField] private CalendarController calendar;

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

    private void Start()
    {
        StartNewDayCycle();
    }


    private void periodCycleReset()
    {
        StartNewDayCycle();
    }

    public void StartNewDayCycle()
    {
        timeController.newPeriodCycle();
    }

    public void NextPeriod()
    {
        timeController.nextPeriod();
    }
}
