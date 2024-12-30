using System;
using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.GamePlay.Infrastructure;

namespace Assets.HomeWork.Develop.CommonUI.GameModeSelect
{
    public class GameModeSelectorPresenter : IInitializable, IDisposable
    {
        // бизнес логика
        private GameModeSelector _gameModeSelector;

        // вью
        private GameModeSelectorView _view;

        public GameModeSelectorPresenter(GameModeSelector gameModeSelector, GameModeSelectorView view)
        {
            _gameModeSelector = gameModeSelector;
            _view = view;
        }

        public void Inintialize()
        {
            _view.PressedButtonNumber += OnPressedButtonNumber;
            _view.PressedButtonLetters += OnPressedButtonLetters;
            _view.SetDescription(_gameModeSelector.ToSetSelectGameModeDescription());
        }

        public void Dispose()
        {
            _view.PressedButtonNumber -= OnPressedButtonNumber;
            _view.PressedButtonLetters -= OnPressedButtonLetters;
        }

        private void OnPressedButtonNumber()
        {
            _gameModeSelector.SetModeNumbers();
        }

        private void OnPressedButtonLetters()
        {
            _gameModeSelector.SetModeLetters();
        }
    }
}
