using Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders;
using Assets.HomeWork.Develop.Utils.Reactive;
using System.Collections.Generic;
using System.Linq;

namespace Assets.HomeWork.Develop.CommonServices.AccountingOfGameResult
{
    public class GameResultService : IDataReader<GameResultsData>, IDataWrite<GameResultsData>
    {        
        private Dictionary<GameResultsTypes, ReactiveVariable<int>> _results = new();

        public int PriceResetGameResult { get; private set; }// поле сколько стоит сбросить результаты игры

        public GameResultService(GameResultsDataProvider gameResultsDataProvider)
        {
            gameResultsDataProvider.RegisterWriter(this);// регаем сами себя
            gameResultsDataProvider.RegisterReader(this);            
        }

        public List<GameResultsTypes> AvailableCurrentResults => _results.Keys.ToList();

        public IReadOnlyVariable<int> GetResults(GameResultsTypes type) => _results[type];

        public void AddResult(GameResultsTypes type) => _results[type].Value++;

        public void ResetAllResults()//Обнуляем результаты игры
        {
            foreach (KeyValuePair<GameResultsTypes, ReactiveVariable<int>> result in _results)
                result.Value.Value = 0;
        }

        public bool HasResultNotZero()
        {
            foreach(KeyValuePair<GameResultsTypes, ReactiveVariable<int>> result in _results)
            {
                if (result.Value.Value > 0) 
                    return true;
            }
            return false;
        }

        public void ReadFrom(GameResultsData gameResultsData)// считываем данные из "GameResultsData" и записываем в "_results"
        {
            foreach (KeyValuePair<GameResultsTypes, int> result in gameResultsData.ResultsData)
            {
                if (_results.ContainsKey(result.Key)) // если тип такого результата игры есть в словаре, то присваиваем ему значение
                    _results[result.Key].Value = result.Value;
                else
                    _results.Add(result.Key, new ReactiveVariable<int>(result.Value));// если нет, то добавляем новый тип и присваиваем ему значение
            }

            PriceResetGameResult = gameResultsData.PriceResetGameResult;
        }

        public void WriteTo(GameResultsData gameResultsData)// считываем данные из "_results" и записываем в "GameResultsData"
        {
            foreach (KeyValuePair<GameResultsTypes, ReactiveVariable<int>> result in _results)
            {
                if (gameResultsData.ResultsData.ContainsKey(result.Key))
                    gameResultsData.ResultsData[result.Key] = result.Value.Value;
                else
                    gameResultsData.ResultsData.Add(result.Key, result.Value.Value);
            }
        }
    }
}
