using Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders;
using System.Collections.Generic;

namespace Assets.HomeWork.Develop.CommonServices.GameService
{
    public class GameService : IDataReader<GameData>
    {
        private List<int> _numbers = new();
        private List<char> _letters = new();

        public IReadOnlyList<int> GetNumbers() => _numbers;  
        public IReadOnlyList<char> GetLetters() => _letters;

        public GameService(GameDataProvider gameDataProvider)
        {
            gameDataProvider.RegisterReader(this);
        }

        public void ReadFrom(GameData data)
        {
            _numbers.AddRange(data.Numbers);
            _letters.AddRange(data.Letters);
        }
    }
}
