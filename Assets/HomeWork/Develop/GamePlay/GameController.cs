using Assets.HomeWork.Develop.CommonServices.AccountingOfGameResult;
using Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders;
using Assets.HomeWork.Develop.CommonServices.Wallet;
using UnityEngine;

namespace Assets.HomeWork.Develop.GamePlay
{
    public class GameController
    {
        private IGame _currentGame;                   

        private GameResultsDataProvider _gameResultsDataProvider;
        private GameResultService _gameResultService;
        private WalletService _walletService;
        private PlayerDataProvider _playerDataProvider;

        private bool _isRuning;       
        private bool _isGameOver;

        public GameController(IGame game,            
                                   
            GameResultsDataProvider gameResultsDataProvider, 
            GameResultService gameResultService, 
            WalletService walletService, 
            PlayerDataProvider playerDataProvider)
        {
            _currentGame = game;
            _gameResultsDataProvider = gameResultsDataProvider;
            _gameResultService = gameResultService;
            _walletService = walletService;
            _playerDataProvider = playerDataProvider;

            StartGame();
        }

        public void Update()
        {
            if (_isRuning == false)
                return;

            if (_isGameOver == false)
                _currentGame.Update();            
        }

        private void StartGame()
        {
            _currentGame.Won += GameModeWon;
            _currentGame.Lost += GameModeLost;

            _isRuning = true;
        }

        private void GameModeLost()
        {
            Debug.Log(" Вы попроиграли! попробуйте ещё раз ");

            _walletService.Spend(CurrencyTypes.Gold);
            _gameResultService.AddResult(GameResultsTypes.Loss);

            _isGameOver = true;           
            GameOver();
        }

        private void GameModeWon()
        {
            Debug.Log(" Ура вы победили!");
           
            _walletService.Add(CurrencyTypes.Gold);
            _gameResultService.AddResult(GameResultsTypes.Win);

            _isGameOver = true;           
            GameOver();
        }

        private void GameOver()
        {
            _playerDataProvider.Save();
            _gameResultsDataProvider.Save();
            Dispose();
        }

        private void Dispose()
        {
            _currentGame.Won -= GameModeWon;
            _currentGame.Lost -= GameModeLost;
        }        
    }
}
