namespace Assets.HomeWork.Develop.GamePlay
{
    public class GameModeFactory
    { 
        public IGame GetGameMode(GameModeID gameModeID)
        {
            IGame gameMode = new Game(gameModeID);
            return gameMode;
        }
    }
}
