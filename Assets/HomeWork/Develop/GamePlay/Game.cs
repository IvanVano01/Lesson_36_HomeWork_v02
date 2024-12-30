using Assets.HomeWork.Develop.CommonServices.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.HomeWork.Develop.GamePlay
{
    public class Game : IGame
    {
        public event Action Won;
        public event Action Lost;
        public event Action<string> SymbolsGenerated;

        private GameService _gameService;        

        private List<char> _randomChairList;
        private List<char> _сhairList;      
        private List<char> _inputCharKeys;

        private int _maxAmountCharLength = 4;

        private bool _isRunning;

        public Game(GameModeID gameModeID, GameService gameService)
        {
            _gameService = gameService;
           
            _randomChairList = new List<char>();
            _сhairList = new List<char>();
            _inputCharKeys = new();

            _сhairList = InintGameMode(gameModeID);

            _isRunning = true;
            
            ToGenerateRandomCharArray();
            ToDisplayOnScreen();
        }

        public string GetSympolList() => string.Join(" ",_randomChairList.ToArray()); // для отображения в UI

        public void Update()
        {
            if (_isRunning == false)
                return;
           
        }        

        public void ToCheckInputSymbol(string inputSymbols)
        {
            _inputCharKeys.Clear();
            _inputCharKeys.AddRange(inputSymbols);
           

            if (_inputCharKeys.Count == _randomChairList.Count)
                ToProcessingGameResult();
            else
                Debug.Log("Вы ввели не правильное кол-во символов, попробуйте ещё раз!");
        }

        private void ToProcessingGameResult()
        {            
            if (_inputCharKeys.SequenceEqual(_randomChairList))
            {
                _isRunning = false;                
                Won?.Invoke();
            }
            else
            {
                _isRunning = false;
                Lost?.Invoke();
            }
        }

        private List<char> InintGameMode(GameModeID gameModeID)
        {
            switch (gameModeID)
            {
                case GameModeID.EnterNumbers:

                    List<char> charsListNumbers = new List<char>();
                             
                    foreach (int number in _gameService.GetNumbers())
                    {
                        charsListNumbers.Add(char.Parse(number.ToString()));
                    }

                    string Symbols = string.Join(" ", _randomChairList.ToArray());
                    SymbolsGenerated?.Invoke(Symbols);                    

                    return charsListNumbers;

                case GameModeID.EnterLetters:

                    List<char> charsListLetters = new List<char>();
                    
                    charsListLetters.AddRange(_gameService.GetLetters());

                    return charsListLetters;

                default:
                    throw new ArgumentOutOfRangeException($" указанный режим не найден {nameof(gameModeID)}");
            }
        }        

        private void ToDisplayOnScreen() => Debug.Log(string.Join(" , ", _randomChairList));

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
