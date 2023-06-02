using Modules.FlappyBirdModule.Scripts.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace Modules.MainModule.Scripts.UI.Button
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class DifficultyButton : ButtonInteraction
    {
        [SerializeField] private Difficulty difficulty;

        public UnityAction<Difficulty> onClick;

        protected override void OnButtonClick()
        {
            base.OnButtonClick();
            onClick?.Invoke(difficulty);
        }
    }
}