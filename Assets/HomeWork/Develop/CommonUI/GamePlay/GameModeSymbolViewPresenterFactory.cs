using Assets.HomeWork.Develop.CommonServices.GameService;

namespace Assets.HomeWork.Develop.CommonUI.GamePlay
{
    public class GameModeSymbolViewPresenterFactory
    {
        private OnlyText _onlyText;

        public GameModeSymbolViewPresenterFactory(OnlyText onlyText)
        {
            _onlyText = onlyText;
        }

        public GameModeSymbolViewPresenter CreateGameModeSymbolViewPresenter(GeneratorRandomSymbolsService generatorRandomSymbolsService)
            => new GameModeSymbolViewPresenter(generatorRandomSymbolsService, _onlyText);
    }
}
