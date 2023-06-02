using UnityEngine;
using Zenject;

namespace Modules.FlappyBirdModule.Scripts.Environment.Obstacle.Factory
{
    public class ObstacleFactory : MonoBehaviour, IObstacleFactory
    {
        [SerializeField] private Obstacle obstaclePrefab;
        [Inject] private IInstantiator instantiator;

        public Obstacle Create()
        {
            var obstacle = instantiator.InstantiatePrefabForComponent<Obstacle>(obstaclePrefab);
            return obstacle;
        }

        public Obstacle Create(Vector3 startPosition)
        {
            var obstacle = instantiator
                .InstantiatePrefabForComponent<Obstacle>(
                    obstaclePrefab, 
                    startPosition, 
                    Quaternion.identity, 
                    null);

            return obstacle;
        }

        public Obstacle Create(Vector3 startPosition, Transform parent)
        {
            var obstacle = instantiator
                .InstantiatePrefabForComponent<Obstacle>(
                    obstaclePrefab, 
                    startPosition,
                    Quaternion.identity, 
                    parent);
            
            return obstacle;
        }

        public Obstacle Create(Vector3 startPosition, Vector3 rotation, Transform parent)
        {
            var obstacle = instantiator
                .InstantiatePrefabForComponent<Obstacle>(
                    obstaclePrefab, 
                    startPosition, 
                    Quaternion.Euler(rotation),
                    parent);
            
            return obstacle;
        }
    }
}