using Assets.HomeWork.Develop.CommonServices.GameService;

namespace Assets.HomeWork.Develop.GamePlay
{
    public class GameModeFactory
    {
        public Game GetGameMode(GeneratorRandomSymbolsService generatorRandomSymbolsService)
        {
            Game gameMode = new Game(generatorRandomSymbolsService);
            return gameMode;
        }
    }
}
