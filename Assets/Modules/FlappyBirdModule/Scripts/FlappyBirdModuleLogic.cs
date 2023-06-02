using System;
using Modules.FlappyBirdModule.Scripts.Camera;
using Modules.FlappyBirdModule.Scripts.Difficulty;
using Modules.FlappyBirdModule.Scripts.Environment.Obstacle.Factory;
using Modules.FlappyBirdModule.Scripts.UI;
using Modules.MainModule.Scripts;
using Modules.MainModule.Scripts.InputServices;
using Modules.MainModule.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Modules.FlappyBirdModule.Scripts
{
    public class FlappyBirdModuleLogic : MonoBehaviour
    {
        [SerializeField] private FlappyBirdModuleUI flappyBirdModuleUI;
        [SerializeField] private string gameScene;

        [SerializeField] private Character.Character characterPrefab;
        [SerializeField] private PlayerCamera playerCameraPrefab;
        [SerializeField] private ObstacleSpawner obstacleSpawnerPrefab;

        private IInstantiator instantiator;
        
        private Character.Character character;
        private PlayerCamera playerCamera;
        private ObstacleSpawner obstacleSpawner;
        
        private InputService inputService;
        private SceneLoader sceneLoader;
        private DifficultySetupsHolder difficultySetupsHolder;
        [Inject]
        private void Construct(SceneLoader sceneLoader, InputService inputService, 
            DifficultySetupsHolder difficultySetupsHolder, IInstantiator instantiator)
        {
            this.sceneLoader = sceneLoader;
            this.inputService = inputService;
            this.difficultySetupsHolder = difficultySetupsHolder;
            this.instantiator = instantiator;
        }

        private void RestartGame()
        {
            sceneLoader.ReloadScene(gameScene);
        }

        private void Awake()
        {
            flappyBirdModuleUI.Initialize();
            flappyBirdModuleUI.StartButtonAddListener(StartGame);
        }

        private void StartGame()
        {
            InstantiateCharacter();
            InstantiatePlayerCamera();
            InstantiateObstacleSpawner();
                
            flappyBirdModuleUI.GameScreen.SetupCharacter(character);
            flappyBirdModuleUI.ShowGameScreen();

            GameSettings.IS_PAUSED = false;
        }

        private void InstantiateCharacter()
        {
            character = instantiator.InstantiatePrefabForComponent<Character.Character>(characterPrefab);
            
            character.SetCharacterMovement(inputService);
            character.OnObstacleCollided += RestartGame;
        }

        private void InstantiatePlayerCamera()
        {
            playerCamera = instantiator.InstantiatePrefabForComponent<PlayerCamera>(playerCameraPrefab);

            playerCamera.SetupCharacter(character);
        }

        private void InstantiateObstacleSpawner()
        {
            obstacleSpawner = instantiator.InstantiatePrefabForComponent<ObstacleSpawner>(obstacleSpawnerPrefab);
            obstacleSpawner.SetupDifficulty(difficultySetupsHolder);
        }

        private void OnDestroy()
        {
            character.OnObstacleCollided -= RestartGame;
        }
    }
}