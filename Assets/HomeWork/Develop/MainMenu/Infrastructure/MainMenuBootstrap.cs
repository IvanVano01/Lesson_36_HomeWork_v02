using Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders;
using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using Assets.HomeWork.Develop.CommonServices.Wallet;
using Assets.HomeWork.Develop.GamePlay.Infrastructure;
using System.Collections;
using UnityEngine;

namespace Assets.HomeWork.Develop.MainMenu.Infrastructure
{
    public class MainMenuBootstrap : MonoBehaviour
    {
        private DIContainer _container;

        private SceneSwitcher _sceneSwitcher;
        private GameModeSelector _gameModeSelector;

        private bool _isRegistrationReady;
        public IEnumerator Run(DIContainer container, MainMenuInputArgs mainMenuInputArgs)
        {
            _container = container;

            ProcessRegistrations();// регистрации для сцены

            Debug.Log($"Подружаем ресурсы для сцены {mainMenuInputArgs}");

            yield return new WaitForSeconds(1f);// симулируем ожидание

            _sceneSwitcher = _container.Resolve<SceneSwitcher>();

            _gameModeSelector = new GameModeSelector(_sceneSwitcher);
            _gameModeSelector.ToSelectGameModeView();

            _isRegistrationReady = true;
        }

        private void ProcessRegistrations()
        {
            // Делаем регистрации для сцены гейплэя

            _container.Initialize();// для создания объектов "NonLazy"
        }

        private void Update()
        { //-----------------------------------------------------------------------------//
            // временно для теста сервиса сохранения и считывания данных
            if (Input.GetKeyDown(KeyCode.S))// сохраняем данные
            {
                _container.Resolve<PlayerDataProvider>().Save();
                Debug.Log(" Сохранили данные");
            }

            if(Input.GetKeyDown(KeyCode.F))// тратим валюты
            {
                WalletService wallet = _container.Resolve<WalletService>();
                wallet.Add(CurrencyTypes.Gold, 100);
                Debug.Log($"Добавили в кошелёк{CurrencyTypes.Gold}" + wallet.GetCurrency(CurrencyTypes.Gold).Value);
            }
          //---------------------------------------------------------------------------//

            if (_isRegistrationReady == false)
                return;
            _gameModeSelector.Update();
        }
    }
}
