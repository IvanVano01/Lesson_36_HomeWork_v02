using Assets.HomeWork.Develop.CommonServices.AccountingOfGameResult;
using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.Configs.Common.GameResult;
using Assets.HomeWork.Develop.Utils.Reactive;
using System;

namespace Assets.HomeWork.Develop.CommonUI.GameResult
{
    public class ResultPresenter : IInitializable, IDisposable 
    {
        // бизнес логика
        private IReadOnlyVariable<int> _result;
        private GameResultsTypes _gameResultsType;
        private ResultTextsConfig _resultTextsConfig;


        // визуал
        private OnlyText _view;

        public ResultPresenter(IReadOnlyVariable<int> result,
            GameResultsTypes gameResultsType,
            OnlyText resultView,
            ResultTextsConfig resultTextsConfig)
        {
            _result = result;
            _gameResultsType = gameResultsType;
            _view = resultView;
            _resultTextsConfig = resultTextsConfig;
        }

        public OnlyText View => _view;// для доступа к вьюхе

        public void Inintialize()
        {
            UpdateValue(_result.Value); ;// отображаем бизнес логику
            _view.SetTextName(_resultTextsConfig.GetResultNameFor(_gameResultsType));

            _result.Changed += OnResultChanged;// подписываемся на изменение бизнес логики
        }

        public void Dispose()
        {
            _result.Changed -= OnResultChanged;
        }

        private void OnResultChanged(int arg1, int newValue)
        {
            UpdateValue(newValue);
        }

        private void UpdateValue(int value) => _view.SetTextValue(value.ToString());
    }
}
