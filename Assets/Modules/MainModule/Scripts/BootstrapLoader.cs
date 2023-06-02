using System.Collections.Generic;
using Modules.MainModule.Scripts.UI;
using Modules.MainModule.Scripts.UI.Screens;
using UnityEngine;
using Zenject;

namespace Modules.MainModule.Scripts
{
    public class BootstrapLoader : MonoBehaviour
    {
        private ModulesSystem modulesSystem;
        private AppsFlyerObjectScript appsFlyerObjectScript;
        private UIManager uiManager;
        [Inject]
        private void Construct(ModulesSystem modulesSystem, AppsFlyerObjectScript appsFlyerObjectScript, UIManager uiManager)
        {
            this.modulesSystem = modulesSystem;
            this.appsFlyerObjectScript = appsFlyerObjectScript;
            this.uiManager = uiManager;

#if !UNITY_EDITOR
            this.appsFlyerObjectScript.onConversionDataLoadSuccess += OnConversionDataLoadSuccess;
            this.appsFlyerObjectScript.onConversionDataLoadFail += OnConversionDataLoadFail;
#endif
            this.appsFlyerObjectScript.Initialize();
            
            this.uiManager.SetScreenActive<LoadingScreen>(true, false);

#if UNITY_EDITOR
            OnConversionDataLoadFail();
#endif
        }

        private void OnConversionDataLoadFail()
        {
            modulesSystem.LoadStartModule();
        }

        private void OnConversionDataLoadSuccess(Dictionary<string, object> data)
        {
            uiManager.ConversionDataOverlay.ShowConversionData(data);
            modulesSystem.LoadStartModule();
        }
    }
}
