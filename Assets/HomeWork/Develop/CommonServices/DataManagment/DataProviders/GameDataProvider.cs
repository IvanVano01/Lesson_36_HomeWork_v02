using Assets.HomeWork.Develop.CommonServices.ConfigsManagment;
using System.Collections.Generic;
using System.Linq;

namespace Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders
{
    public class GameDataProvider : DataProvider<GameData>
    {

        private ConfigsProviderService _configsProviderService;

        public GameDataProvider(ISaveLoadService saveLoadService, ConfigsProviderService configsProviderService) : base(saveLoadService)
        {
            _configsProviderService = configsProviderService;
        }

        protected override GameData GetOriginData()
        {
           return new GameData()
            {
               Numbers = InitNumbers(),
               Letters = Initletters()
           };
        }

        private List<int> InitNumbers()
        {
            List<int> numbers = new List<int>();

            numbers = _configsProviderService.StartGameConfig.GetNumbers.ToList();

            return numbers;
        }

        private List<char> Initletters()
        {
            List<char> letters = new();

            letters = _configsProviderService.StartGameConfig.GetLetters.ToList();
            
            return letters;
        }
    }
}
