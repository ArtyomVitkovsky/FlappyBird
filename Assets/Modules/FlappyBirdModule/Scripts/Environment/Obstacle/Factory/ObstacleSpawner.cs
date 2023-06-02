using Modules.FlappyBirdModule.Scripts.Difficulty;
using Modules.MainModule.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.FlappyBirdModule.Scripts.Environment.Obstacle.Factory
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private Transform obstaclesHolder;
        [SerializeField] private float distanceToResseter;
        [SerializeField] private float distanceToPlayer;
        [SerializeField] private int poolSize;
        private ObjectsPool<Obstacle> obstaclePool;

        private DifficultySetup currentDifficulty;

        private Vector3 startPositionAfterReset;
        
        private IObstacleFactory obstacleFactory;
        [Inject]
        private void Construct(IObstacleFactory obstacleFactory)
        {
            this.obstacleFactory = obstacleFactory;
        }

        public void SetupDifficulty(DifficultySetupsHolder difficultySetupsHolder)
        {
            currentDifficulty = difficultySetupsHolder.GetDifficultySetup();
        }

        private void Start()
        {
            obstaclePool = new ObjectsPool<Obstacle>(poolSize, true);

            var distance = poolSize * (currentDifficulty.ObstacleDistance);
            var totalObstacleWidths = poolSize * currentDifficulty.ObstacleWidth;

            obstaclesHolder.position = new Vector3(0, 0, distance + totalObstacleWidths + distanceToResseter + distanceToPlayer);

            var currentPosition = obstaclesHolder.position;

            for (int i = 0; i < poolSize; i++)
            {
                currentPosition.y = Random.Range(
                    currentDifficulty.HolePositionClamp.x,
                    currentDifficulty.HolePositionClamp.y);
                
                var obstacle = obstacleFactory.Create(currentPosition, obstaclesHolder);
                
                obstacle.SetHoleSize(currentDifficulty.HoleSize);
                obstacle.SetWidth(currentDifficulty.ObstacleWidth);
                obstacle.SetSpeed(currentDifficulty.ObstacleSpeed);
                
                obstacle.OnObstacleReset += RebuildObstacle;
                
                obstaclePool.AddObjectToPool(new PoolObject<Obstacle>(obstacle));
                
                currentPosition.z -= currentDifficulty.ObstacleDistance + currentDifficulty.ObstacleWidth / 2f;

                obstacle.isActive = true;
                obstacle.Move();
            }
        }

        private void RebuildObstacle(Obstacle obstacle)
        {
            var targetPosition = obstaclesHolder.position;
            targetPosition.y = Random.Range(
                currentDifficulty.HolePositionClamp.x,
                currentDifficulty.HolePositionClamp.y);
            targetPosition.z -= distanceToPlayer - distanceToResseter;

            obstacle.transform.position = targetPosition;
            obstacle.isActive = true;
            obstacle.Move();
        }
    }
}