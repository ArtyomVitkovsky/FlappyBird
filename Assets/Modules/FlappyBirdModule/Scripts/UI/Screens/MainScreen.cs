using Modules.MainModule.Scripts.UI.Interfaces;
using UnityEngine;

namespace Modules.FlappyBirdModule.Scripts.UI.Screens
{
    public class MainScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private ButtonInteraction startButton;
        [SerializeField] private ButtonInteraction difficultyButton;

        public ButtonInteraction StartButton => startButton;

        public ButtonInteraction DifficultyButton => difficultyButton;
        
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void Initialize()
        {
            startButton.Initialize();
            difficultyButton.Initialize();
        }
    }
}