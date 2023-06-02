using System;
using Modules.MainModule.Scripts.Sound;
using Modules.MainModule.Scripts.UI.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Modules.MainModule.Scripts.UI.Screens
{
    public class SettingsScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private ButtonInteraction closeButton;
        [SerializeField] private Slider slider;

        private PlayerData playerData;
        private SoundControl soundControl;

        public ButtonInteraction CloseButton => closeButton;

        [Inject]
        private void Construct(PlayerData playerData, SoundControl soundControl)
        {
            this.playerData = playerData;
            this.soundControl = soundControl;

            slider.SetValueWithoutNotify(this.playerData.settings.Value.soundVolume);
        }

        private void Awake()
        {
            slider.onValueChanged.AddListener(SetVolume);
            soundControl.SyncSoundWithSettings();
        }

        private void SetVolume(float volume)
        {
            playerData.settings.Value.soundVolume = volume;
            playerData.settings.Save();

            soundControl.SyncSoundWithSettings();
        }

        public void Initialize()
        {
            closeButton.Initialize();
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);

            GameSettings.IS_PAUSED = isActive;
            GameSettings.TIME_SCALE = isActive ? 0 : 1;
        }
    }
}