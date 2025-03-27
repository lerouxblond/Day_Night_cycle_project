using UnityEngine;
using TimePeriods.Model;
using TimePeriods.UI;
using System;
using UnityEngine.Events;

namespace TimePeriods
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField] private TimeDataSO timeData;
        [SerializeField] public TimePeriod currentTimePeriod {get; private set;}

        [SerializeField] private TimeUI timeUIPrefab;
        [SerializeField] private Transform parentTransformPrefab;
        [SerializeField] private TimeUI timeUIInstance;
        [SerializeField] private EnvironmentController environmentManager;

        public event UnityAction InformAboutCycleReset;

        void Awake()
        {
            InitUIInstance();
            InitTimeData();
            

            SetTimePeriod(currentTimePeriod);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                nextPeriod();
        }

        private void InitUIInstance()
        {
            if(timeUIInstance == null)
            {
                TimeUI timeUI = Instantiate(timeUIPrefab, parentTransformPrefab);
                timeUIInstance = timeUI;
            }
            else
                return;
        }

        private void InitTimeData()
        {
            if(!timeData.isInit)
                currentTimePeriod = timeData.getFirstTimePeriod();
            else
                currentTimePeriod = timeData.getCurrentTimePeriod();
                
        }

        public void SetTimePeriod(TimePeriod timePeriod)
        {
            environmentManager.newBackground(timePeriod.timePeriod.backgroundParallaxPrefab);
            timeUIInstance.updatePeriodUI(timePeriod.timePeriod.periodName);
        }

        public void nextPeriod()
        {
            (TimePeriod period, bool ResetDay) = timeData.getNextTimePeriod();
            if(ResetDay)
            {
                InformAboutCycleReset?.Invoke();
                newPeriodCycle();
            }
            else
            {
                currentTimePeriod = period;
                SetTimePeriod(currentTimePeriod);
            }
        }

        public void newPeriodCycle()
        {
            currentTimePeriod = timeData.getFirstTimePeriod();
            SetTimePeriod(currentTimePeriod);
        }
    }

}