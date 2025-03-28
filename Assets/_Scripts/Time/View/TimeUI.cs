using UnityEngine;
using UnityEngine.UI;

namespace TimePeriods.UI
{
    public class TimeUI : MonoBehaviour
    {
        [SerializeField] private Text periodText;
        public void updatePeriodUI(string periodName)
        {
            periodText.text = periodName;
        }
    }
}   