using Assets.HomeWork.Develop.GamePlay.Infrastructure;

namespace Assets.HomeWork.Develop.CommonUI.GameModeSelect
{
    public class ModeSelectorPresenterFactory
    { 
        public GameModeSelectorPresenter CreateGameModeSelectorPresenter(GameModeSelector gameModeSelector, GameModeSelectorView view)
            => new GameModeSelectorPresenter(gameModeSelector, view);
    }
}
