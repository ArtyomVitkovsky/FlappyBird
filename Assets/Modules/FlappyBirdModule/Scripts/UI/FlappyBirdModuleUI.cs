using System;
using Modules.FlappyBirdModule.Scripts.UI.Screens;
using Modules.MainModule.Scripts;
using Modules.MainModule.Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Zenject;

namespace Modules.FlappyBirdModule.Scripts.UI
{
    public class FlappyBirdModuleUI : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;

        [SerializeField] private MainScreen mainScreen;
        [SerializeField] private GameScreen gameScreen;
        [SerializeField] private DifficultyScreen difficultyScreen;
        [SerializeField] private CurrentDifficultyUI currentDifficulty;
        

        public GameScreen GameScreen => gameScreen;

        private UIManager uiManager;

        [Inject]
        private void Construct(UIManager uiManager)
        {
            this.uiManager = uiManager;
            
            canvas.renderMode = this.uiManager.Canvas.renderMode;
            canvas.worldCamera = this.uiManager.Camera;
            canvas.planeDistance = this.uiManager.Canvas.planeDistance;
        }

        public void Initialize()
        {
            difficultyScreen.OnDifficultyChanged += currentDifficulty.SetView;
            difficultyScreen.Initialize();
            mainScreen.Initialize();
            
            DifficultyButtonAddListener(ShowDifficultyScreen);
            
            difficultyScreen.BackButton.AddPersistentListener(ShowMainScreen);

            uiManager.AddScreen(mainScreen);
            uiManager.AddScreen(gameScreen);
            uiManager.AddScreen(difficultyScreen);
            
            ShowMainScreen();
        }

        public void StartButtonAddListener(UnityAction action)
        {
            mainScreen.StartButton.AddPersistentListener(action);
        }
        
        public void DifficultyButtonAddListener(UnityAction action)
        {
            mainScreen.DifficultyButton.AddPersistentListener(action);
        }
        
        public void ShowDifficultyScreen()
        {
            uiManager.SetScreenActive<DifficultyScreen>(true, false);
        }
        
        public void ShowGameScreen()
        {
            uiManager.SetScreenActive<GameScreen>(true, false);
        }

        public void ShowMainScreen()
        {
            uiManager.SetScreenActive<MainScreen>(true, false);
        }

        private void OnDestroy()
        {
            uiManager.RemoveScreen(mainScreen);
            uiManager.RemoveScreen(gameScreen);
            uiManager.RemoveScreen(difficultyScreen);
        }
    }
}