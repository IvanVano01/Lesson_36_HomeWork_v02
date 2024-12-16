using Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders;
using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.CommonServices.LoadingScreen;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using System.Collections;
using UnityEngine;

namespace Assets.HomeWork.Develop.EntryPoint
{
    public class Bootstrap : MonoBehaviour
    {
        public IEnumerator Run(DIContainer container)
        {
            ILoadingCurtain loadingCurtain = container.Resolve<ILoadingCurtain>();
            SceneSwitcher sceneSwitcher = container.Resolve<SceneSwitcher>();// берём из контейнера "SceneSwitcher" для перехода в другую сцену

            loadingCurtain.Show(); //Включаем загрузочную штору 

            Debug.Log("Начинается инициализация сервисов");

            // Инициализация всех сервисов(конфиги, инит сервисы рекламы/ аналитики)

            container.Resolve<PlayerDataProvider>().Load();// подгружаем данные для игрока

            yield return new WaitForSeconds(1.5f);// заглушка, имитирует инициализацию сервисов которые выше

            Debug.Log("Все сервисы проекта инициализированны! Переходим на слудующую сцену.");
            loadingCurtain.Hide(); // скрываем штору
            
            // переход на следующую сцену с помощью сервиса смены сцены

            sceneSwitcher.ProcessSwitchSceneFor( new OutputBootstrapArgs( new MainMenuInputArgs()));// из сцены "Bootstrap" переходим в "MainMenu"
        }
    }
}
