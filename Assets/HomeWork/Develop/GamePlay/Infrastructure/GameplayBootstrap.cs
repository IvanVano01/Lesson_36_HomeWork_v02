using Assets.HomeWork.Develop.CommonServices.AccountingOfGameResult;
using Assets.HomeWork.Develop.CommonServices.AssetManagment;
using Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders;
using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.CommonServices.GameService;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using Assets.HomeWork.Develop.CommonServices.Wallet;
using Assets.HomeWork.Develop.CommonUI.GamePlay;
using Assets.HomeWork.Develop.GamePlay.UI;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.HomeWork.Develop.GamePlay.Infrastructure
{
    public class GameplayBootstrap : MonoBehaviour
    {
        private DIContainer _container;
        private GameplayInputArgs _gameplayInputArgs;       
        private GameController _gameController;       

        private bool _isRuning;

        public IEnumerator Run(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            _container = container;
            _gameplayInputArgs = gameplayInputArgs;

            ProcessRegistrations();

            Debug.Log($"Подружаем ресурсы для режима игры под номером: {gameplayInputArgs.GameMode}");

            Game game = _container.Resolve<Game>();
            GameModeSymbolViewPresenter gameModeSymbolViewPresenter = _container
                .Resolve<GameModeSymbolViewPresenterFactory>().CreateGameModeSymbolViewPresenter(game);
            gameModeSymbolViewPresenter.Enable();


            GameResultsDataProvider gameResultsDataProvider = _container.Resolve<GameResultsDataProvider>();
            PlayerDataProvider playerDataProvider = _container.Resolve<PlayerDataProvider>();
            GameResultService gameResultService = _container.Resolve<GameResultService>();
            WalletService walletService = _container.Resolve<WalletService>();

            Debug.Log("Сцена готова, можно начинать игру! ");
            yield return new WaitForSeconds(1f);// симулируем ожидание

            _gameController = new GameController(
                game,
                gameResultsDataProvider,
                gameResultService, walletService, playerDataProvider);

            _isRuning = true;
        }

        private void ProcessRegistrations()
        {
            // регаем всё что нужно для этой сцены

            _container.RegisterAsSingle(c => new GamePlayUIRootFactory(_container));

            _container.RegisterAsSingle(c => c.Resolve<GamePlayUIRootFactory>().SpawnGamePlayUIRoot()).NonLazy();// регаем и спавним "GamePlayUIRoot"

            _container.RegisterAsSingle(c => new GameModeSymbolViewPresenterFactory(c.Resolve<GamePlayUIRoot>().OnlyText));

            _container.RegisterAsSingle(c => new InputSymbolPresenterFactory());

            _container.RegisterAsSingle(c => new GameModeFactory(c.Resolve<GameService>()));

            _container.RegisterAsSingle(c => new Game(_gameplayInputArgs.GameMode, c.Resolve<GameService>())); // регаем "Game"

            _container.RegisterAsSingle(c => c.Resolve<InputSymbolPresenterFactory>()
            .CreateInputSymbolPresenter(c.Resolve<GamePlayUIRoot>().InputSymbolView, c.Resolve<Game>())).NonLazy();// регаем "CreateInputSymbol"

            _container.RegisterAsSingle(c => new ResultGameViewPrezenterFactory(c.Resolve<SceneSwitcher>(), _gameplayInputArgs,
                c.Resolve<GamePlayUIRoot>().ResultGameView));

            _container.RegisterAsSingle(c => c.Resolve<ResultGameViewPrezenterFactory>().
            CreateResultGameViewPrezenter(c.Resolve<Game>())).NonLazy();                                 // регаем"ResultGameViewPrezenter"

            _container.Initialize();// для создания объектов "NonLazy"
        }

        private void Update()
        {
            if (_isRuning == false)
                return;

            _gameController.Update();
        }
    }
}
