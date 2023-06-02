using Modules.FlappyBirdModule.Scripts.Difficulty;
using Modules.MainModule.Scripts.UI.Button;
using Modules.MainModule.Scripts.UI.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Modules.FlappyBirdModule.Scripts.UI.Screens
{
    public class DifficultyScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private DifficultyButton[] difficultyButtons;

        [SerializeField] private ButtonInteraction backButton;

        public UnityAction<Enums.Difficulty> OnDifficultyChanged;
        
        public ButtonInteraction BackButton => backButton;
        

        private DifficultySetupsHolder difficultySetupsHolder;
        private PlayerData playerData;
        [Inject]
        private void Construct(DifficultySetupsHolder difficultySetupsHolder, PlayerData playerData)
        {
            this.difficultySetupsHolder = difficultySetupsHolder;
            this.playerData = playerData;
        }

        private void SetupButtons()
        {
            backButton.Initialize();
            
            foreach (var button in difficultyButtons)
            {
                button.Initialize();
                button.onClick += SetDifficulty;
            }
        }

        public void Initialize()
        {
            SetupButtons();

            difficultySetupsHolder.SetDifficulty(playerData.settings.Value.difficulty);
            OnDifficultyChanged?.Invoke(playerData.settings.Value.difficulty);
        }

        private void SetDifficulty(Enums.Difficulty difficulty)
        {
            difficultySetupsHolder.SetDifficulty(difficulty);

            playerData.settings.Value.difficulty = difficulty;
            playerData.settings.Save();
            
            OnDifficultyChanged?.Invoke(difficulty);
        }

        private void OnDestroy()
        {
            foreach (var button in difficultyButtons)
            {
                button.onClick -= SetDifficulty;
            }
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}
