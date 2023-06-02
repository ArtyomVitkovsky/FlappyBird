using System.Linq;
using UnityEngine;

namespace Modules.FlappyBirdModule.Scripts.Difficulty
{
    public class DifficultySetupsHolder : MonoBehaviour
    {
        [SerializeField] private DifficultySetup[] setups;

        private Enums.Difficulty currentDifficulty = Enums.Difficulty.Easy;
        
        public DifficultySetup GetDifficultySetup()
        {
            var result = setups.FirstOrDefault(s => s.Difficulty == currentDifficulty);

            if (result == null)
            {
                Debug.LogWarning($"Difficulty {currentDifficulty} not found!");
                result = setups[0];
            }

            return result;
        }

        public void SetDifficulty(Enums.Difficulty difficulty)
        {
            currentDifficulty = difficulty;
        }
    }
}