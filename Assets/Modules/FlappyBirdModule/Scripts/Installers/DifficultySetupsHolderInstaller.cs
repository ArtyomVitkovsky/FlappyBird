using Modules.FlappyBirdModule.Scripts.Difficulty;
using UnityEngine;
using Zenject;

namespace Modules.FlappyBirdModule.Scripts.Installers
{
    public class DifficultySetupsHolderInstaller : MonoInstaller
    {
        [SerializeField] private DifficultySetupsHolder difficultySetupsHolderPrefab;
        public override void InstallBindings()
        {
            var difficultySetupsHolderInstance = Container
                .InstantiatePrefabForComponent<DifficultySetupsHolder>(difficultySetupsHolderPrefab);
    
            Container.Bind<DifficultySetupsHolder>().FromInstance(difficultySetupsHolderInstance).AsSingle();
        }
    }
}