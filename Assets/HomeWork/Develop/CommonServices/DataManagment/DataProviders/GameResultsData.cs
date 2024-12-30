using Assets.HomeWork.Develop.CommonServices.AccountingOfGameResult;
using System;
using System.Collections.Generic;

namespace Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders
{
    [Serializable]

    public class GameResultsData : ISaveData
    {
        public Dictionary<GameResultsTypes, int> ResultsData;// данные ввиде словаря, который будет хранить кол-во побед и поражений

        public int PriceResetGameResult;
    }
}
