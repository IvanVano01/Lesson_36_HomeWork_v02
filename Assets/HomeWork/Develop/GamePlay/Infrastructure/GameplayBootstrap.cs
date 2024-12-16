using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.HomeWork.Develop.GamePlay.Infrastructure
{
    public class GameplayBootstrap : MonoBehaviour
    {
        private DIContainer _container;

        private SceneSwitcher _sceneSwitcher;
        private GameController _gameController;        

        private bool _isRuning;

        public IEnumerator Run(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            _container = container;

            ProcessRegistrations();

            Debug.Log($"Подружаем ресурсы для режима игры под номером: {gameplayInputArgs.GameMode}"); 

            _sceneSwitcher = _container.Resolve<SceneSwitcher>();
            GameModeFactory gameModeFactory = new GameModeFactory();
           
            Debug.Log("Сцена готова, можно начинать игру! ");
            yield return new WaitForSeconds(1f);// симулируем ожидание
            
            _gameController = new GameController(_sceneSwitcher,gameModeFactory, gameplayInputArgs);
            _isRuning = true;
        }

        private void ProcessRegistrations()
        {
            // регаем всё что нужно для этой сцены

            _container.Initialize();// для создания объектов "NonLazy"
        }

        private void Update()
        {
            if (_isRuning == false)
                return;            

            _gameController.Update();
        }        
    }
}
