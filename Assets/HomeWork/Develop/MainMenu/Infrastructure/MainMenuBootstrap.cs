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

            ProcessRegistrations();// ����������� ��� �����

            Debug.Log($"��������� ������� ��� ����� {mainMenuInputArgs}");

            yield return new WaitForSeconds(1f);// ���������� ��������

            _sceneSwitcher = _container.Resolve<SceneSwitcher>();

            _gameModeSelector = new GameModeSelector(_sceneSwitcher);
            _gameModeSelector.ToSelectGameModeView();

            _isRegistrationReady = true;
        }

        private void ProcessRegistrations()
        {
            // ������ ����������� ��� ����� �������

            _container.Initialize();// ��� �������� �������� "NonLazy"
        }

        private void Update()
        { //-----------------------------------------------------------------------------//
            // �������� ��� ����� ������� ���������� � ���������� ������
            if (Input.GetKeyDown(KeyCode.S))// ��������� ������
            {
                _container.Resolve<PlayerDataProvider>().Save();
                Debug.Log(" ��������� ������");
            }

            if(Input.GetKeyDown(KeyCode.F))// ������ ������
            {
                WalletService wallet = _container.Resolve<WalletService>();
                wallet.Add(CurrencyTypes.Gold, 100);
                Debug.Log($"�������� � ������{CurrencyTypes.Gold}" + wallet.GetCurrency(CurrencyTypes.Gold).Value);
            }
          //---------------------------------------------------------------------------//

            if (_isRegistrationReady == false)
                return;
            _gameModeSelector.Update();
        }
    }
}
