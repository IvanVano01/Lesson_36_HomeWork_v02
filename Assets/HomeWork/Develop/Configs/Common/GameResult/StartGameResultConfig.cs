using Assets.HomeWork.Develop.CommonServices.AccountingOfGameResult;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.HomeWork.Develop.Configs.Common.GameResult
{
    [CreateAssetMenu(menuName = "Configs/Common/GameResult/NewGameResultConfig", fileName = "GameResultConfig")]

    [Serializable]

    public class StartGameResultConfig : ScriptableObject
    {        
        [SerializeField] private List<GameResultConfig> _values = new List<GameResultConfig>();

        public int GetValuesFor(GameResultsTypes gameResultsTypes) => _values.First(configs => configs.Type == gameResultsTypes).Value;

        [field: SerializeField, Range(0, 1000)] public int PriceResetGameResult { get; private set; }

        [Serializable]
        private class GameResultConfig
        {
            [field: SerializeField] public GameResultsTypes Type { get; private set; }
            [field: SerializeField, Range(0, 20)] public int Value { get; private set; }
        }
    }
}
