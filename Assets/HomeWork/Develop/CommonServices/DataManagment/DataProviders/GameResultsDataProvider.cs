using Assets.HomeWork.Develop.CommonServices.AccountingOfGameResult;
using Assets.HomeWork.Develop.CommonServices.ConfigsManagment;
using System;
using System.Collections.Generic;

namespace Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders
{
    public class GameResultsDataProvider : DataProvider<GameResultsData> // провайдер для данных результа игры(GameResultsData),
                                                                         // унаследован от абстракции  "DataProvider"
    {
        private ConfigsProviderService _configsProviderService;

        public GameResultsDataProvider(ISaveLoadService saveLoadService, ConfigsProviderService configsProviderService) : base(saveLoadService)
        {
            _configsProviderService = configsProviderService;
        }       

        protected override GameResultsData GetOriginData()// метод для создания данных по дефолту
        {
            return new GameResultsData()
            {
                ResultsData = InitResultData(),// создаём данные
                PriceResetGameResult = _configsProviderService.StartGameResultConfig.PriceResetGameResult
            };
        }

        private Dictionary<GameResultsTypes, int> InitResultData()
        {
            Dictionary<GameResultsTypes, int> resultsData = new();

            // здесь зделать подгрузку из конфига "GameResultConfig"
            foreach (GameResultsTypes gameResultype in Enum.GetValues(typeof(GameResultsTypes)))// заполняем словарь, типом результатов игры
                                                                                                // которые перечисленны в энамке 
            {
                resultsData.Add(gameResultype, _configsProviderService.StartGameResultConfig.GetValuesFor(gameResultype));
                //resultsData.Add(gameResultype, 0);// присваиваем значения по умолчанию
            }
            return resultsData;
        }

    }
}
