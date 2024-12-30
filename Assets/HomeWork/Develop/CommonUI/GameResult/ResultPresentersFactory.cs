using Assets.HomeWork.Develop.CommonServices.AccountingOfGameResult;
using Assets.HomeWork.Develop.CommonServices.ConfigsManagment;
using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.CommonServices.Wallet;

namespace Assets.HomeWork.Develop.CommonUI.GameResult
{
    public class ResultPresentersFactory
    {
        private GameResultService _gameResultService;
        private GameResetResultService _gameResetResultService;
        private ConfigsProviderService _configProviderService;

        public ResultPresentersFactory(DIContainer container)
        {
            _gameResultService = container.Resolve<GameResultService>();
            _configProviderService = container.Resolve<ConfigsProviderService>();
            _gameResetResultService = container.Resolve<GameResetResultService>();
        }

        public GameResultPresenter CreateGameResultPresenter(OnlyTextListView view)
            => new GameResultPresenter(_gameResultService, view, this);

        public ResultPresenter CreateResultPresenter(OnlyText view, GameResultsTypes gameResultsType)
        => new ResultPresenter(_gameResultService.GetResults(gameResultsType), gameResultsType, view, _configProviderService.ResultTextsConfig);

        public GameResetResultPresenter CreateGameResetResultPresenter(ButtonWithText buttonWithText, CurrencyTypes currencyType)
            => new GameResetResultPresenter(_gameResetResultService,
                _configProviderService.StartGameResultConfig, currencyType, buttonWithText);
    }
}
