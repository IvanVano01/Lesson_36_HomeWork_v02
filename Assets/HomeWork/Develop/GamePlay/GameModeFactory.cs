using Assets.HomeWork.Develop.CommonServices.GameService;
using Assets.HomeWork.Develop.CommonUI.GamePlay;

namespace Assets.HomeWork.Develop.GamePlay
{
    public class GameModeFactory
    { 
        private GameService _gameService;

        public GameModeFactory(GameService gameService)
        {
            _gameService = gameService;
        }

        public Game GetGameMode(GameModeID gameModeID)
        {
            Game gameMode = new Game(gameModeID, _gameService);
            return gameMode;
        }
    }
}
