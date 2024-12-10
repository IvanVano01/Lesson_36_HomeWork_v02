using Assets.HomeWork.Develop.CommonServices.AssetManagment;
using Assets.HomeWork.Develop.CommonServices.CoroutinePerformer;
using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.CommonServices.LoadingScreen;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using System;
using UnityEngine;

namespace Assets.HomeWork.Develop.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Bootstrap _gameBootstrap;

        private void Awake()
        {
            SetupAppSettings();

            DIContainer projectContainer = new DIContainer();

            // регистрация сервисов на целый проект
            //Самый родительский контейнер "projectContainer"

            RegisterResourcesAssetLoader(projectContainer);// регаем в глобальный контейнер
            RegisterCoroutinePerformer(projectContainer);// регаем сервис для запуска корутин
            RegisterLoadingCurtain(projectContainer);//регаем загрузочную штору
            RegisterSceneLoader(projectContainer);// регаем загрузчик сцен
            RegisterSceneSceneSwitcher(projectContainer);// регаем сервис перехода из сцены в другую

            // когда все глобальные регистрации прошли
            projectContainer.Resolve<ICoroutinePerformer>().StartPerform(_gameBootstrap.Run(projectContainer));//в "_gameBootstrap" через сервис корутины запустим Run и передадим

        }

        private void SetupAppSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 144;
        }

        private void RegisterSceneSceneSwitcher(DIContainer container)
        {
            container.RegisterAsSingle(c => new SceneSwitcher(
                c.Resolve<ICoroutinePerformer>(),
                c.Resolve<ILoadingCurtain>(),
                c.Resolve<ISceneLoader>(),
                c));
        }

        private void RegisterResourcesAssetLoader(DIContainer container)// метод для регистрации(сервисов) в контейнер
            => container.RegisterAsSingle(c => new ResourcesAssetLoader());

        private void RegisterCoroutinePerformer(DIContainer container)//сервис для запуска корутин
        {
            container.RegisterAsSingle<ICoroutinePerformer>(c =>
            {
                ResourcesAssetLoader resourcesAssetLoader = c.Resolve<ResourcesAssetLoader>(); // получаем из контейнера загрузчик ресурсов,
                                                                                               // который подгружает ресурсы из папки "Resources" 
                CoroutinePerformer coroutinePerformerPrefab = resourcesAssetLoader.LoadResource<CoroutinePerformer>(InfrastructureAssetPath.CoroutinePerformerPath);// погружаем прифаб

                return Instantiate(coroutinePerformerPrefab);
            });
        }

        private void RegisterLoadingCurtain(DIContainer сontainer)// метод регистрации загрузочной шторки
        {
            сontainer.RegisterAsSingle<ILoadingCurtain>(c =>
            {
                ResourcesAssetLoader resourcesAssetLoader = c.Resolve<ResourcesAssetLoader>();

                StandartLoadingCurtain standartLoadingCurtainPrefab = resourcesAssetLoader.LoadResource<StandartLoadingCurtain>(InfrastructureAssetPath.LoadingCurtainPath);// погружаем прифаб

                return Instantiate(standartLoadingCurtainPrefab);
            });
        }

        private void RegisterSceneLoader(DIContainer сontainer)// метод регистрации загрузчика сцен
        {
            сontainer.RegisterAsSingle<ISceneLoader>(c => new DefaultSceneLoader());
        }
    }
}
