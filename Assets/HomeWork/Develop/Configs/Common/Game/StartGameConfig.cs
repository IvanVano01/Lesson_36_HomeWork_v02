using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.Develop.Configs.Common.Game
{
    [CreateAssetMenu(menuName = "Configs/Common/Game/NewGameConfig", fileName = "StartGameConfig")]
    
    [Serializable]
    public class StartGameConfig : ScriptableObject
    {
        [SerializeField] private List<int> _numbers = new List<int>();
        [SerializeField] private List<char> _letters = new List<char>();

        public IReadOnlyList<int> GetNumbers => _numbers;
        public IReadOnlyList<char> GetLetters => _letters;
    }
}
