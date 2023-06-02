using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Modules.MainModule.Scripts.UI
{
    public class AppsflyerConversionDataOverlay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI conversionData;

        public void ShowConversionData(Dictionary<string, object> dataMap)
        {
            foreach (var data in dataMap)
            {
                conversionData.text += $"{data.Key} : {data.Value}\n";
            }
        }
    }
}