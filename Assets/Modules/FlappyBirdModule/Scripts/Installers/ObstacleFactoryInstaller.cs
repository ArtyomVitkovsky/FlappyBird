using Modules.FlappyBirdModule.Scripts.Environment.Obstacle.Factory;
using UnityEngine;
using Zenject;

namespace Modules.FlappyBirdModule.Scripts.Installers
{
    public class ObstacleFactoryInstaller : MonoInstaller
    {
        [SerializeField] private ObstacleFactory obstacleFactory;
        public override void InstallBindings()
        {
            Container.Bind<IObstacleFactory>().FromInstance(obstacleFactory).AsSingle();
        }
    }
}