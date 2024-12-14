using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using Assets.HomeWork.Develop.GamePlay;
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
           
            _gameModeSelector = new GameModeSelector(_sceneSwitcher);
            _gameModeSelector.ToSelectGameModeView();

            _isRegistrationReady = true;
        }

        private void ProcessRegistrations()        {
            
            // ������ ����������� ��� ����� �������
           _sceneSwitcher = _container.Resolve<SceneSwitcher>();
        }

        private void Update()
        {
            if (_isRegistrationReady == false)
                return;
            _gameModeSelector.Update();           
        }
    }
}