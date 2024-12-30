using Assets.HomeWork.Develop.GamePlay;

namespace Assets.HomeWork.Develop.CommonUI.GamePlay
{
    public class GameModeSymbolViewPresenterFactory
    {
        private OnlyText _onlyText;

        public GameModeSymbolViewPresenterFactory(OnlyText onlyText)
        {
            _onlyText = onlyText;
        }

        public GameModeSymbolViewPresenter CreateGameModeSymbolViewPresenter(Game game)
            => new GameModeSymbolViewPresenter(game, _onlyText);
    }
}
