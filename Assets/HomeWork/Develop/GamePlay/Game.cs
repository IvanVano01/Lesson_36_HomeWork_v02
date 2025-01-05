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

        private GeneratorRandomSymbolsService _generatorRandomSymbolsService;

        private List<char> _randomChairList;
        private List<char> _inputCharKeys;

        private bool _isRunning;

        public Game(GeneratorRandomSymbolsService generatorRandomSymbolsService)
        {
            _generatorRandomSymbolsService = generatorRandomSymbolsService;

            _randomChairList = new();
            _inputCharKeys = new();            
            _randomChairList = _generatorRandomSymbolsService.RandomChairList.ToList();

            _isRunning = true; 
        }

        public string GetSympolList() => string.Join(" ", _randomChairList.ToArray()); // для отображения в UI

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
    }
}
