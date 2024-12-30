using Assets.HomeWork.Develop.CommonServices.AccountingOfGameResult;
using Assets.HomeWork.Develop.CommonServices.AssetManagment;
using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using Assets.HomeWork.Develop.CommonServices.Wallet;
using Assets.HomeWork.Develop.CommonUI.GameModeSelect;
using Assets.HomeWork.Develop.CommonUI.GameResult;
using Assets.HomeWork.Develop.CommonUI.Wallet;
using Assets.HomeWork.Develop.GamePlay.Infrastructure;
using Assets.HomeWork.Develop.MainMenu.UI;
using System.Collections;
using UnityEngine;

namespace Assets.HomeWork.Develop.MainMenu.Infrastructure
{
    public class MainMenuBootstrap : MonoBehaviour
    {
        private DIContainer _container;

        private GameModeSelectorPresenter _gameModePresenter;

        private bool _isRegistrationReady;

        public IEnumerator Run(DIContainer container, MainMenuInputArgs mainMenuInputArgs)
        {
            _container = container;

            ProcessRegistrations();// регистрации для сцены

            Debug.Log($"Подружаем ресурсы для сцены {mainMenuInputArgs}");

            yield return new WaitForSeconds(1f);// симулируем ожидание

            _gameModePresenter = _container.Resolve<GameModeSelectorPresenter>();
            _gameModePresenter.Inintialize();

            Debug.Log($" Загрузка ресурсов для сцены, заверщена!");
            _isRegistrationReady = true;
        }

        private void ProcessRegistrations()
        {
            // Делаем регистрации для сцены гейплэя
            _container.RegisterAsSingle(c => new WalletPresenterFactory(c));// создаем "WalletPresenterFactory" и передаём туда контейнер
            _container.RegisterAsSingle(c => new ResultPresentersFactory(c));
            _container.RegisterAsSingle(c => new GameModeSelectorFactory(c));
            _container.RegisterAsSingle(c => new ModeSelectorPresenterFactory());
            _container.RegisterAsSingle(c => new GameResetResultService(c.Resolve<WalletService>(), c.Resolve<GameResultService>()));

            _container.RegisterAsSingle(c =>
            {
                MainMenuUIRoot mainMenuUIRootPrefab = c.Resolve<ResourcesAssetLoader>().LoadResource<MainMenuUIRoot>("MainMenu/UI/MainMenuUIRoot");

                return Instantiate(mainMenuUIRootPrefab);
            }).NonLazy();

            _container.RegisterAsSingle(c => c.Resolve<WalletPresenterFactory>()
            .CreateCurrencyPresenter(c.Resolve<MainMenuUIRoot>().CurrencyView, CurrencyTypes.Gold)).NonLazy();// для отображения и обновления валют на протяжении всей жизни сцены

            _container.RegisterAsSingle(c => c.Resolve<ResultPresentersFactory>()
            .CreateGameResultPresenter
            (c.Resolve<MainMenuUIRoot>().GameResultView)).NonLazy();  //регаем "GameResultPresenter"

            _container.RegisterAsSingle(c => c.Resolve<ResultPresentersFactory>()
            .CreateGameResetResultPresenter(c.Resolve<MainMenuUIRoot>().ResetGameResultView, CurrencyTypes.Gold)).NonLazy(); //регаем "GameResetResultPresenter"

            _container.RegisterAsSingle(c => c.Resolve<ModeSelectorPresenterFactory>()
            .CreateGameModeSelectorPresenter(_container.Resolve<GameModeSelectorFactory>()
            .CreateGameModeSelector(), _container.Resolve<MainMenuUIRoot>().GameModeSelectorView)); // регаем "GameModeSelectorPresenter"

            _container.Initialize();// для создания объектов "NonLazy"            
        }

        private void Update()
        {
            
        }
    }
}
