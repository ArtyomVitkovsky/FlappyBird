using System;
using Modules.MainModule.Scripts.UI.Interfaces;
using UnityEngine;

namespace Modules.MainModule.Scripts.UI.Screens
{
    public class SettingsPanel : MonoBehaviour, IScreen
    {
        [SerializeField] private ButtonInteraction settingsButton;

        public ButtonInteraction SettingsButton => settingsButton;
        
        public void Initialize()
        {
            settingsButton.Initialize();
        }

        public void SetActive(bool isActive)
        {
            
        }
    }
}
