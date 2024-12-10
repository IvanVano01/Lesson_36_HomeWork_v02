using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using System.Collections;
using UnityEngine;

namespace Assets.HomeWork.Develop.MainMenu.Infrastructure
{
    public class MainMenuBootstrap : MonoBehaviour
    {
        private DIContainer _container;

        public IEnumerator Run(DIContainer container, MainMenuInputArgs mainMenuInputArgs)
        {
            _container = container;

            ProcessRegistrations();// ����������� ��� �����

            Debug.Log($"��������� ������� ��� ����� {mainMenuInputArgs}");

            yield return new WaitForSeconds(1f);// ���������� ��������

            Debug.Log(" �������� ����� ����!");
            Debug.Log("��� ������ ����, ������� ������� 1 ");
            Debug.Log("��� ������ ����, ������� ������� 2 ");
        }

        private void ProcessRegistrations()
        {
            // ������ ����������� ��� ����� �������
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputMainMenuArgs(new GameplayInputArgs(1)));

            if (Input.GetKeyDown(KeyCode.Alpha2))
                _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputMainMenuArgs(new GameplayInputArgs(2)));
        }
    }
}