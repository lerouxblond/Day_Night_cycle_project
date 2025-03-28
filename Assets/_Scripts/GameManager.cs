using System;
using TimePeriods;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    [SerializeField] private TimeController timeController;
    [SerializeField] private screenFader screenFader;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            StartFadeTransition(NextPeriod);
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

    public void StartFadeTransition(System.Action methodToExecute)
    {
        screenFader.StartFadeTransition(methodToExecute);
    }
}