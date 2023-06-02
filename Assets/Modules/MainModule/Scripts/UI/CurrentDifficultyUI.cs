using System.Linq;
using Modules.FlappyBirdModule.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.MainModule.Scripts.UI
{
    public class CurrentDifficultyUI : MonoBehaviour
    {
        [SerializeField] private Image view;
        [SerializeField] private TextMeshProUGUI difficultyName;
        [SerializeField] private DifficultyView[] difficultyViews;

        public void SetView(Difficulty difficulty)
        {
            if (difficultyViews == null || difficultyViews.Length == 0)
            {
                Debug.LogError("difficultyViews is NULL or EMPTY");
                return;
            }
            
            var currentView = difficultyViews.FirstOrDefault(v => v.Difficulty == difficulty);

            if (currentView.View == null)
            {
                currentView = difficultyViews[0];
            }

            view.sprite = currentView.View;
            difficultyName.text = difficulty.ToString();
        }
    }
}
