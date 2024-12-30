using Assets.HomeWork.Develop.CommonServices.AccountingOfGameResult;
using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.Configs.Common.GameResult;
using System;
using System.Collections.Generic;

namespace Assets.HomeWork.Develop.CommonUI.GameResult
{
    public class GameResultPresenter : IInitializable, IDisposable
    {
        // моель
        private GameResultService _gameResultService;
        private ResultPresentersFactory _resultPresenterFactory;
        private ResultTextsConfig _resultTextsConfig;

        private List<ResultPresenter> _resultPresenters = new();

        // вью
        private OnlyTextListView _view;

        public GameResultPresenter(GameResultService gameResultService, OnlyTextListView view, ResultPresentersFactory factory)
        {
            _gameResultService = gameResultService;
            _view = view;
            _resultPresenterFactory = factory;            
        }

        public void Inintialize()
        {
            foreach (GameResultsTypes gameResultsType in _gameResultService.AvailableCurrentResults)
            {
                // создать для всех доступных результатов игры, вьюхи
                OnlyText resultView = _view.SpawnElement();

                // создать призетер
                ResultPresenter resultPresenter = _resultPresenterFactory.CreateResultPresenter(resultView, gameResultsType);
                resultPresenter.Inintialize();
                _resultPresenters.Add(resultPresenter);

                // проинитить презентер
            }
        }

        public void Dispose()
        {
            // удалить вьюхи
            foreach(ResultPresenter resultPresenter in _resultPresenters)
            {
                _view.Remove(resultPresenter.View);                
                resultPresenter.Dispose();// диинитить все призентеры
            }

            _resultPresenters.Clear();
        }
    }
}
