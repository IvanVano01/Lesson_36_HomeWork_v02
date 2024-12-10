using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.HomeWork.Develop.GamePlay.Infrastructure
{
    public class GameplayBootstrap : MonoBehaviour
    {
        private DIContainer _container;

        private IGameMode _gameMode;

        private bool _isRuning;
        private int _currentGameMode;

        public IEnumerator Run(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            _container = container;

            ProcessRegistrations();

            Debug.Log($"Подружаем ресурсы для режима игры под номером: {gameplayInputArgs.GameMode}");
            //Debug.Log("Создаём персонажа");
            Debug.Log("Сцена готова, можно начинать игру! ");


            yield return new WaitForSeconds(1f);// симулируем ожидание

            _currentGameMode = gameplayInputArgs.GameMode;
            _gameMode = SwitchGameMode(_currentGameMode);
            _isRuning = true;
        }

        private void ProcessRegistrations()
        {
            // регаем всё что нужно для этой сцены
        }

        private void Update()
        {
            if (_isRuning == false)
                return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_gameMode.IsWin && _gameMode.IsGameOver)
                    _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputGameplayArgs(new MainMenuInputArgs()));

                if (_gameMode.IsWin == false && _gameMode.IsGameOver)
                    _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputGameplayArgs(new GameplayInputArgs(_currentGameMode)));
            }

            _gameMode.Update();
        }

        private IGameMode SwitchGameMode(int gameLevel)
        {
            switch (gameLevel)
            {
                case 1:
                    IGameMode gameMode1 = new GameEnterNumbers();                    
                    return gameMode1;
                case 2:
                    IGameMode gameMode2 = new GameEnterLetters();
                    return gameMode2;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameLevel));
            }
        }
    }
}
