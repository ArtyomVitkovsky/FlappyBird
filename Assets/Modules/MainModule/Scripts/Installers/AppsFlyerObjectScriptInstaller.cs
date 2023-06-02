using UnityEngine;
using Zenject;

namespace Modules.MainModule.Scripts.Installers
{
    public class AppsFlyerObjectScriptInstaller : MonoInstaller
    {
        [SerializeField] private AppsFlyerObjectScript appsFlyerPrefab;
        public override void InstallBindings()
        {
            var appsFlyerInstance = Container
                .InstantiatePrefabForComponent<AppsFlyerObjectScript>(appsFlyerPrefab);

            Container.Bind<AppsFlyerObjectScript>().FromInstance(appsFlyerInstance).AsSingle();
        }
    }
}