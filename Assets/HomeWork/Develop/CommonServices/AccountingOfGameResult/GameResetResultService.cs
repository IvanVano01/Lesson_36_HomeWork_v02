using Assets.HomeWork.Develop.CommonServices.Wallet;

namespace Assets.HomeWork.Develop.CommonServices.AccountingOfGameResult
{
    public class GameResetResultService
    {
        private WalletService _walletService;
        private GameResultService _gameResultService;
        private string _textButton = " Reset";

        public GameResetResultService(WalletService walletService, GameResultService gameResultService)
        {
            _walletService = walletService;
            _gameResultService = gameResultService;
        }

        public string TextButton => _textButton;

        public void ResetResultForCurrency(CurrencyTypes currencyType, int amount)
        {
            if (_walletService.HasEnough(currencyType, amount) && _gameResultService.HasResultNotZero())
            {
                _walletService.Spend(currencyType);
                _gameResultService.ResetAllResults();
            }
        }
    }
}
