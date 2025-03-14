using UnityEngine;
using TimePeriods.Model;
using TimePeriods.UI;
using System;

namespace TimePeriods
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField] private TimeDataSO timeData;
        [SerializeField] private TimePeriod currentTimePeriod;

        [SerializeField] private TimeUI timeUIPrefab;
        [SerializeField] private Transform parentTransformPrefab;
        [SerializeField] private TimeUI timeUIInstance;
        [SerializeField] private EnvironmentController environmentManager;

        void Awake()
        {
            InitUIInstance();
            InitTimeData();

            SetTimePeriod(currentTimePeriod);
        }

        private void SetTimePeriod(TimePeriod timePeriod)
        {
            environmentManager.changeBackground(timePeriod.timePeriod.backgroundParallaxPrefab);
            timeUIInstance.updatePeriodUI(timePeriod.timePeriod.periodName);
        }

        private void InitUIInstance()
        {
            if(timeUIInstance == null)
                Instantiate(timeUIPrefab, parentTransformPrefab);
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
    }

}