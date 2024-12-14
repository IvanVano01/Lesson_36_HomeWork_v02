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

        private List<char> _randomChairList;
        private List<char> _сhairList;
        private List<char> _inputCharKeys;

        private int _maxAmountCharLength = 4;

        private bool _isRunning;

        public Game(GameModeID gameModeID)
        {
            _inputCharKeys = new();
            _randomChairList = new List<char>();
            _сhairList = new List<char>();

            _сhairList = InintGameMode(gameModeID);

            _isRunning = true;

            ToGenerateRandomCharArray();
            ToDisplayOnScreen();
        }

        public void Update()
        {
            if (_isRunning == false)
                return;

            ToEnterChar();
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

                    charsListNumbers.AddRange(new[]{
                        '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
                    });

                    return charsListNumbers;

                case GameModeID.EnterLetters:

                    List<char> charsListLetters = new List<char>();

                    charsListLetters.AddRange(new[]{
                        'a','b', 'c', 'd','e','f','g','h','j','k','l'
                    });
                    return charsListLetters;

                default:
                    throw new ArgumentOutOfRangeException($" указанный режим не найден {nameof(gameModeID)}");
            }
        }

        private void ToEnterChar()
        {
            if (_inputCharKeys.Count >= _randomChairList.Count)
                return;

            if (Input.anyKeyDown)
            {
                Char char1;
                string inputKey = Input.inputString;

                if (char.TryParse(inputKey, out char result))
                {
                    char1 = result;
                    Debug.Log(" Вы ввели символ " + char1);
                    _inputCharKeys.Add(char1);

                    if (_inputCharKeys.Count == _randomChairList.Count)
                    {
                        ToProcessingGameResult();
                        return;
                    }
                    Debug.Log(" Введите следущий символ");

                    return;
                }
                Debug.Log(" Вы нажали не известную клавишу, попробуйте ещё раз " + Input.inputString);
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
