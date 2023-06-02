using UnityEngine;

namespace Modules.FlappyBirdModule.Scripts.Difficulty
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Difficulty", fileName = "DifficultySetup_0")]
    public class DifficultySetup : ScriptableObject
    {
        [SerializeField] private float obstacleDistance;
        [SerializeField] private float holeSize;
        [SerializeField] private float obstacleWidth;
        [SerializeField] private float obstacleSpeed;
        [SerializeField] private Vector2 holePositionClamp;
        [SerializeField] private Enums.Difficulty difficulty;

        public float ObstacleDistance => obstacleDistance;

        public float HoleSize => holeSize;
        
        public float ObstacleWidth => obstacleWidth;

        public Vector2 HolePositionClamp => holePositionClamp;

        public Enums.Difficulty Difficulty => difficulty;

        public float ObstacleSpeed => obstacleSpeed;
    }
}