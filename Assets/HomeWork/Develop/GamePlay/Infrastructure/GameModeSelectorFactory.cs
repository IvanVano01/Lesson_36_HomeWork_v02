using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;

namespace Assets.HomeWork.Develop.GamePlay.Infrastructure
{
    public class GameModeSelectorFactory
    {
        private SceneSwitcher _sceneSwitcher;

        public GameModeSelectorFactory(DIContainer container)
        {
            _sceneSwitcher = container.Resolve<SceneSwitcher>();
        }

        public GameModeSelector CreateGameModeSelector() => new GameModeSelector(_sceneSwitcher);
    }
}
