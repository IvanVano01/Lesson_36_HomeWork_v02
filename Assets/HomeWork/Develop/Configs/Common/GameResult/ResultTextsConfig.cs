using Assets.HomeWork.Develop.CommonServices.AccountingOfGameResult;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.HomeWork.Develop.Configs.Common.GameResult
{
    [CreateAssetMenu(menuName = "Configs/Common/GameResult/NewResultTextConfig", fileName = "ResultTextConfig")]
    public class ResultTextsConfig : ScriptableObject
    {
        [SerializeField] private List<ResulTextConfig> _resulConfigs;

        private void OnValidate()
        {
            // проверки на дубликаты и т.д
        }

        public string GetResultNameFor(GameResultsTypes type) => _resulConfigs.First(config => config.GameResultsType == type).ResultName;

        [Serializable]
        private class ResulTextConfig
        {
            [field: SerializeField] public GameResultsTypes GameResultsType { get; private set; }
            [field: SerializeField] public String ResultName { get; private set; }
        }
    }
}
