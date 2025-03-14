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
        
        public bool isInit { get; set; } = false;

        public TimePeriod getCurrentTimePeriod()
        {
            return listOfTimePeriod[currentPeriodIndex];
        }

        public (TimePeriod, bool) getNextTimePeriod()
        {
            if (currentPeriodIndex >= listOfTimePeriod.Count-1)
            {
                currentPeriodIndex = 0;
                return (getFirstTimePeriod(), true);
            }
            else
            {
                currentPeriodIndex++;
                return (listOfTimePeriod[currentPeriodIndex], false);
            }
        }

        public TimePeriod getFirstTimePeriod()
        {
            return listOfTimePeriod[currentPeriodIndex];
        }
    }

    [Serializable]
    public struct TimePeriod
    {
        [field: SerializeField] public TimePeriodSO timePeriod { get; set; }

    }

}