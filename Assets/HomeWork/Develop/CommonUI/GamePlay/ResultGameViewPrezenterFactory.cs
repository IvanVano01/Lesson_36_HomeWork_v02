using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using Assets.HomeWork.Develop.GamePlay;

namespace Assets.HomeWork.Develop.CommonUI.GamePlay
{
    public class ResultGameViewPrezenterFactory
    {
        private SceneSwitcher _sceneSwitcher;
        private GameplayInputArgs _gameplayInputArgs;
        private ResultGameView _resultGameview;

        public ResultGameViewPrezenterFactory
            (SceneSwitcher sceneSwitcher,
            GameplayInputArgs gameplayInputArgs,
            ResultGameView resultGameview)
        {
            _sceneSwitcher = sceneSwitcher;
            _gameplayInputArgs = gameplayInputArgs;
            _resultGameview = resultGameview;
        }

        public ResultGameViewPrezenter CreateResultGameViewPrezenter(Game game)
            => new ResultGameViewPrezenter(game, _sceneSwitcher, _gameplayInputArgs, _resultGameview);
    }
}
