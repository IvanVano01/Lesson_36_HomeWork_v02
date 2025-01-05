using Assets.HomeWork.Develop.GamePlay;
using System;
using System.Collections.Generic;

namespace Assets.HomeWork.Develop.CommonServices.GameService
{
    public class GeneratorRandomSymbolsService
    {
        private GameSettingsService _gameSettingsService;
        private List<char> _randomChairList;
        private List<char> _сhairList;
        private int _maxAmountCharLength;

        public GeneratorRandomSymbolsService(GameModeID gameModeID, GameSettingsService gameSettingsService)
        {
            _gameSettingsService = gameSettingsService;
            _randomChairList =new List<char>();
            _сhairList = new List<char>();
            _maxAmountCharLength = _gameSettingsService.MaxAmountCharLength;
            _сhairList = InintGameMode(gameModeID);

            ToGenerateRandomCharArray();
        }

        public string GetSympolList() => string.Join(" ", _randomChairList.ToArray()); // для отображения в UI
        public IReadOnlyList<char> RandomChairList => _randomChairList; // для доступа чтения к сгенерированному массиву 

        private List<char> InintGameMode(GameModeID gameModeID)
        {
            switch (gameModeID)
            {
                case GameModeID.EnterNumbers:

                    List<char> charsListNumbers = new List<char>();

                    foreach (int number in _gameSettingsService.GetNumbers())
                    {
                        charsListNumbers.Add(char.Parse(number.ToString()));
                    }

                    return charsListNumbers;

                case GameModeID.EnterLetters:

                    List<char> charsListLetters = new List<char>();

                    charsListLetters.AddRange(_gameSettingsService.GetLetters());

                    return charsListLetters;

                default:
                    throw new ArgumentOutOfRangeException($" указанный режим не найден {nameof(gameModeID)}");
            }
        }

        private void ToGenerateRandomCharArray()
        {
            for (int i = 0; i < _maxAmountCharLength; i++)
                _randomChairList.Add(GenerateRandomChar());
        }

        private char GenerateRandomChar()
        {
            int randomElement = UnityEngine.Random.Range(0, _сhairList.Count);

            return _сhairList[randomElement];
        }
    }
}
