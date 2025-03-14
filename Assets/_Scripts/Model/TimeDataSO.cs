using System;
using System.Collections.Generic;
using UnityEngine;

namespace TimePeriods.Model
{
    [CreateAssetMenu(fileName = "TimeDataSO", menuName = "Scriptable Objects/TimePeriod/TimeDataSO")]
    public class TimeDataSO : ScriptableObject
    {
        [field: SerializeField] public List<TimePeriod> listOfTimePeriod { get; set; }
        [field: SerializeField] public int currentPeriodIndex { get; set; } = 0;
        public event Action<TimePeriod> informAboutTimeUpdate;
        public bool isInit { get; set; } = false;

        public TimePeriod getCurrentTimePeriod()
        {
            return listOfTimePeriod[currentPeriodIndex];
        }

        public TimePeriod getNextTimePeriod()
        {
            if (currentPeriodIndex >= listOfTimePeriod.Count)
            {
                informAboutTimeUpdate?.Invoke(getFirstTimePeriod());
                return getFirstTimePeriod();
            }
            else
            {
                informAboutTimeUpdate?.Invoke(listOfTimePeriod[currentPeriodIndex+1]);
                return listOfTimePeriod[currentPeriodIndex+1];
            }
        }

        public TimePeriod getFirstTimePeriod()
        {
            currentPeriodIndex = 0;
            return listOfTimePeriod[currentPeriodIndex];
        }
    }

    [Serializable]
    public struct TimePeriod
    {
        [field: SerializeField] public TimePeriodSO timePeriod { get; set; }

    }

}