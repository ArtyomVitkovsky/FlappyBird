using System;
using Modules.MainModule.Scripts;
using Modules.MainModule.Scripts.InputServices;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Modules.FlappyBirdModule.Scripts.Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterMovement characterMovement;
        
        public UnityAction OnObstaclePassed;
        public UnityAction OnObstacleCollided;

        private bool isCollided;


        public void SetCharacterMovement(InputService inputService)
        {
            characterMovement.SetupInputService(inputService);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(GameSettings.IS_PAUSED || isCollided) return;

            isCollided = true;
            
            if (other.CompareTag("Obstacle"))
            {
                GameSettings.IS_PAUSED = true;
                OnObstacleCollided?.Invoke();
            }
            else if (other.CompareTag("ObstaclePassedTrigger"))
            {
                OnObstaclePassed?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            isCollided = false;
        }
    }
}