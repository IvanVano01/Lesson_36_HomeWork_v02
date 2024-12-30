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

            ProcessRegistrations();// ����������� ��� �����

            Debug.Log($"��������� ������� ��� ����� {mainMenuInputArgs}");

            yield return new WaitForSeconds(1f);// ���������� ��������

            _gameModePresenter = _container.Resolve<GameModeSelectorPresenter>();
            _gameModePresenter.Inintialize();

            Debug.Log($" �������� �������� ��� �����, ���������!");
            _isRegistrationReady = true;
        }

        private void ProcessRegistrations()
        {
            // ������ ����������� ��� ����� �������
            _container.RegisterAsSingle(c => new WalletPresenterFactory(c));// ������� "WalletPresenterFactory" � ������� ���� ���������
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
            .CreateCurrencyPresenter(c.Resolve<MainMenuUIRoot>().CurrencyView, CurrencyTypes.Gold)).NonLazy();// ��� ����������� � ���������� ����� �� ���������� ���� ����� �����

            _container.RegisterAsSingle(c => c.Resolve<ResultPresentersFactory>()
            .CreateGameResultPresenter
            (c.Resolve<MainMenuUIRoot>().GameResultView)).NonLazy();  //������ "GameResultPresenter"

            _container.RegisterAsSingle(c => c.Resolve<ResultPresentersFactory>()
            .CreateGameResetResultPresenter(c.Resolve<MainMenuUIRoot>().ResetGameResultView, CurrencyTypes.Gold)).NonLazy(); //������ "GameResetResultPresenter"

            _container.RegisterAsSingle(c => c.Resolve<ModeSelectorPresenterFactory>()
            .CreateGameModeSelectorPresenter(_container.Resolve<GameModeSelectorFactory>()
            .CreateGameModeSelector(), _container.Resolve<MainMenuUIRoot>().GameModeSelectorView)); // ������ "GameModeSelectorPresenter"

            _container.Initialize();// ��� �������� �������� "NonLazy"            
        }

        private void Update()
        {
            
        }
    }
}
