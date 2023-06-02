using System.Collections.Generic;
using Modules.FlappyBirdModule.Scripts.UI;
using Modules.MainModule.Scripts.UI.Interfaces;
using Modules.MainModule.Scripts.UI.Screens;
using UnityEngine;
using UnityEngine.Serialization;

namespace Modules.MainModule.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private Camera camera;
        [SerializeField] private LoadingScreen loadingScreen;
        [SerializeField] private SettingsPanel settingsPanel;
        [SerializeField] private SettingsScreen settingsScreen;
        [SerializeField] private AppsflyerConversionDataOverlay appsflyerConversionDataOverlay;

        private List<IScreen> screens;

        public AppsflyerConversionDataOverlay ConversionDataOverlay => appsflyerConversionDataOverlay;

        public Camera Camera => camera;

        public Canvas Canvas => canvas;

        private void Awake()
        {
            screens ??= new List<IScreen>();
            screens.Capacity = 4;
            
            screens.Add(loadingScreen);
            screens.Add(settingsScreen);
            
            settingsPanel.Initialize();
            settingsPanel.SettingsButton.AddPersistentListener(ShowSettingsScreen);
            
            settingsScreen.Initialize();
            settingsScreen.CloseButton.AddPersistentListener(CloseSettingsScreen);
        }

        public void AddScreen(IScreen screen)
        {
            screens ??= new List<IScreen>();
            
            if(screens.Contains(screen)) return;
            
            screens.Add(screen);
        }
        
        public void RemoveScreen(IScreen screen)
        {
            screens.Remove(screen);
        }

        public void SetScreenActive<T>(bool isActive, bool asOverlay)
        {
            foreach (var screen in screens)
            {
                var screenTypeMatched = screen.GetType() == typeof(T);

                if (asOverlay && !screenTypeMatched)
                {
                    continue;
                }
                screen.SetActive(isActive && screenTypeMatched);
            }
        }

        private void ShowSettingsScreen()
        {
            SetScreenActive<SettingsScreen>(true, true);
        }
        
        private void CloseSettingsScreen()
        {
            SetScreenActive<SettingsScreen>(false, true);
        }
    }
}