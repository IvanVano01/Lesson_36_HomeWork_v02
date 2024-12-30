using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using Assets.HomeWork.Develop.GamePlay;
using System;

namespace Assets.HomeWork.Develop.CommonUI.GamePlay
{
    public class ResultGameViewPrezenter : IInitializable, IDisposable
    {      
        private Game _game;
        private SceneSwitcher _sceneSwitcher;
        private GameModeID _currentGameModeID;

        private ResultGameView _resultGameview;
        private WinView _winView;
        private DefeatView _defeatView;

        public ResultGameViewPrezenter(Game game, SceneSwitcher sceneSwitcher, GameplayInputArgs gameplayInputArgs, ResultGameView resultGameview)
        {           
            _game = game;
            _sceneSwitcher = sceneSwitcher;
            _currentGameModeID = gameplayInputArgs.GameMode;
            _resultGameview = resultGameview;
            _winView = _resultGameview.WinView;
            _defeatView = _resultGameview.DefeatView;
        }

        public void Inintialize()
        {
            _winView.ButtonToMainMenu.PressedButton += OnMainMenuPressedButton;
            _defeatView.ButtonReturnGame.PressedButton += OnReturnGamePressedButton;
            _game.Lost += OnGameLost;
            _game.Won += OnGameWon;
        }

        public void Dispose()
        {
            _winView.ButtonToMainMenu.PressedButton -= OnMainMenuPressedButton;
            _defeatView.ButtonReturnGame.PressedButton -= OnReturnGamePressedButton;
            _game.Lost -= OnGameLost;
            _game.Won -= OnGameWon;
        }

        private void OnGameWon()
        {
            _resultGameview.Show();
            _resultGameview.WinView.Show();
        }

        private void OnGameLost()
        {
            _resultGameview.Show();
            _resultGameview.DefeatView.Show();
        }

        private void OnReturnGamePressedButton()
        {
            _sceneSwitcher.ProcessSwitchSceneFor(new OutputGameplayArgs(new GameplayInputArgs(_currentGameModeID)));
        }

        private void OnMainMenuPressedButton()
        {           
            _sceneSwitcher.ProcessSwitchSceneFor(new OutputGameplayArgs(new MainMenuInputArgs()));
        }
    }
}
