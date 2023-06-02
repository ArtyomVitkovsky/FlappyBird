using System;
using Modules.MainModule.Scripts;
using Modules.MainModule.Scripts.UI.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Modules.FlappyBirdModule.Scripts.UI.Screens
{
    public class GameScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private int score;
        
        private Character.Character character;
        public void SetupCharacter(Character.Character character)
        {
            this.character = character;
            this.character.OnObstaclePassed += OnObstaclePassed;
        }

        private void OnObstaclePassed()
        {
            score++;
            UpdateScoreText();
        }

        public void Initialize()
        {
            GameSettings.IS_PAUSED = true;
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        private void UpdateScoreText()
        {
            scoreText.text = $"{score}";
        }

        private void OnDestroy()
        {
            character.OnObstaclePassed -= OnObstaclePassed;
        }
    }
}