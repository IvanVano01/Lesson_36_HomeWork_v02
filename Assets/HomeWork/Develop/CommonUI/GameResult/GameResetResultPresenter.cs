using Assets.HomeWork.Develop.CommonServices.AccountingOfGameResult;
using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.CommonServices.Wallet;
using Assets.HomeWork.Develop.Configs.Common.GameResult;
using System;

namespace Assets.HomeWork.Develop.CommonUI.GameResult
{
    public class GameResetResultPresenter : IInitializable, IDisposable
    {        
        private GameResetResultService _gameResetResultService;
        private StartGameResultConfig _startGameResultConfig;
        private CurrencyTypes _currencyType;

        private ButtonWithText _buttonWithText;

        public GameResetResultPresenter(GameResetResultService gameResetResultService,
            StartGameResultConfig startGameResultConfig,
            CurrencyTypes currencyType,
            ButtonWithText buttonWithText)
        {            
            _gameResetResultService = gameResetResultService;
            _startGameResultConfig = startGameResultConfig;
            _currencyType = currencyType;
            _buttonWithText = buttonWithText;
        }

        public void Inintialize()
        {
            _buttonWithText.PressedButton += OnPressedButton;
            _buttonWithText.SetText(_gameResetResultService.TextButton);
        }

        public void Dispose()
        {
            _buttonWithText.PressedButton -= OnPressedButton;
        }

        private void OnPressedButton()
        {
            _gameResetResultService.ResetResultForCurrency(_currencyType, _startGameResultConfig.PriceResetGameResult);            
        }        
    }
}
