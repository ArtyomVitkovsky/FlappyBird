using System;
using Modules.FlappyBirdModule.Scripts.Enums;
using UnityEngine;

namespace Modules.MainModule.Scripts.UI
{
    [Serializable]
    public struct DifficultyView
    {
        [SerializeField] private Sprite view;
        [SerializeField] private Difficulty difficulty;

        public Difficulty Difficulty => difficulty;

        public Sprite View => view;
    }
}