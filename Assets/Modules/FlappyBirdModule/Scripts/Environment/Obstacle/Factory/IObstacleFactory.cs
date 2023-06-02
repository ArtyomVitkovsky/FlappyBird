using UnityEngine;

namespace Modules.FlappyBirdModule.Scripts.Environment.Obstacle.Factory
{
    interface IObstacleFactory
    {
        public Obstacle Create();
        public Obstacle Create(Vector3 startPosition);
        public Obstacle Create(Vector3 startPosition, Transform parent);
        public Obstacle Create(Vector3 startPosition, Vector3 rotation ,Transform parent);
    }
}