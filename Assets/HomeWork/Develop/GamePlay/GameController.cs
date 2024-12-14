using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.HomeWork.Develop.GamePlay
{
    public class GameController
    {
        private SceneSwitcher _sceneSwitcher;        

        private IGame _currentGameMode;
        private GameModeFactory _gameModeFactory;
        private GameModeID _currentGameModeID;

        private bool _isRuning;
        private bool _isWin;
        private bool _isGameOver;

        public GameController(SceneSwitcher sceneSwitcher, GameModeFactory gameModeFactory, GameplayInputArgs gameplayInputArgs)
        {
            _sceneSwitcher = sceneSwitcher;
            _gameModeFactory = gameModeFactory;
            _currentGameModeID = gameplayInputArgs.GameMode;

            StartGame();
        }

        public void Update()
        {
            if (_isRuning == false)
                return;          


            if (_isGameOver == false)
                _currentGameMode.Update();
            else
                ProcessSelectInputPlayer();
        }

        private void StartGame()
        {
            SetGameMode(_currentGameModeID);

            _currentGameMode.Won += GameModeWon;
            _currentGameMode.Lost += GameModeLost;

            _isRuning = true;
        }

        private void GameModeLost()
        {
            Debug.Log(" Вы попроиграли! \n  Нажмите пробел и попробуйте ещё раз ");
            _isGameOver = true;
            _isWin = false;
        }

        private void GameModeWon()
        {
            Debug.Log(" Ура вы победили!");
            Debug.Log(" Нажмите пробел что бы перейти в Главное меню ");
            _isGameOver = true;
            _isWin = true;
        }

        private void GameOver()
        {
            Dispose();
        }

        private void Dispose()
        {
            _currentGameMode.Won -= GameModeWon;
            _currentGameMode.Lost -= GameModeLost;
        }

        private void ProcessSelectInputPlayer()
        {
            if (_isGameOver == false)
                return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isWin)
                {
                    GameOver();
                    _sceneSwitcher.ProcessSwitchSceneFor(new OutputGameplayArgs(new MainMenuInputArgs()));
                }

                if (_isWin == false)
                {
                    GameOver();
                    _sceneSwitcher.ProcessSwitchSceneFor(new OutputGameplayArgs(new GameplayInputArgs(_currentGameModeID)));
                }
            }
        }

        private void SetGameMode(GameModeID gameModeID)
        {
            _currentGameMode = _gameModeFactory.GetGameMode(gameModeID);
        }
    }
}
